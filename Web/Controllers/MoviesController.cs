using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;
using TicketCinema.Models.DomainModels;
using TicketCinema.Models.DTO;
using TicketCinema.Service.Interface;

namespace TicketCinema.Web.Controllers
{
    public class MoviesController : Controller
    {
        private readonly IMovieService _movieService;
        private readonly ILogger<MoviesController> _logger;

        public MoviesController(ILogger<MoviesController> logger, IMovieService movieService)
        {
            _logger = logger;
            _movieService = movieService;
        }

        // GET: Movies
        public IActionResult Index()
        {
            _logger.LogInformation("User Request -> Get All Movies!");
            return View(_movieService.GetAllMovies());
        }

        // GET: Movies/Details/5
        public IActionResult Details(Guid? id)
        {
            _logger.LogInformation("User Request -> Get Details For Movie");
            if (id == null)
            {
                return NotFound();
            }

            var movie = _movieService.GetDetailsForMovie(id);
            if (movie == null)
            {
                return NotFound();
            }

            return View(movie);
        }

        // GET: Movies/Create
        public IActionResult Create()
        {
            _logger.LogInformation("User Request -> Get create form for Movie!");
            return View();
        }

        // POST: Movies/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create([Bind("Id,MovieName,MovieImage,MovieDescription,MoviePrice,MovieRating")] Movie movie)
        {
            _logger.LogInformation("User Request -> Inser Movie in DataBase!");
            if (ModelState.IsValid)
            {
                movie.Id = Guid.NewGuid();
                _movieService.CreateNewMovie(movie);
                return RedirectToAction(nameof(Index));
            }
            return View(movie);
        }

        // GET: Movies/Edit/5
        public IActionResult Edit(Guid? id)
        {
            _logger.LogInformation("User Request -> Get edit form for Movie!");
            if (id == null)
            {
                return NotFound();
            }

            var movie = _movieService.GetDetailsForMovie(id);
            if (movie == null)
            {
                return NotFound();
            }
            return View(movie);
        }

        // POST: Movies/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Guid id, [Bind("Id,MovieName,MovieImage,MovieDescription,MoviePrice,MovieRating")] Movie movie)
        {
            _logger.LogInformation("User Request -> Update Movie in DataBase!");

            if (id != movie.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _movieService.UpdeteExistingMovie(movie);
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!MovieExists(movie.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(movie);
        }

        // GET: Movies/Delete/5
        public IActionResult Delete(Guid? id)
        {
            _logger.LogInformation("User Request -> Get delete form for Movie!");

            if (id == null)
            {
                return NotFound();
            }

            var movie = _movieService.GetDetailsForMovie(id);
            if (movie == null)
            {
                return NotFound();
            }

            return View(movie);
        }

        // POST: Movies/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(Guid id)
        {
            _logger.LogInformation("User Request -> Delete Movie in DataBase!");

            _movieService.DeleteMovie(id);
            return RedirectToAction(nameof(Index));
        }


        public IActionResult AddMovieToCart(Guid id)
        {
            var result = _movieService.GetShoppingCartInfo(id);
            return View(result);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult AddMovieToCart(AddToShoppingCartDto model)
        {

            _logger.LogInformation("User Request -> Add Movie in ShoppingCart and save changes in database!");


            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);

            var result = _movieService.AddToShoppingCart(model, userId);

            if (result)
            {
                return RedirectToAction("Index", "Movies");
            }
            return View(model);
        }
        private bool MovieExists(Guid id)
        {
            return _movieService.GetDetailsForMovie(id) != null;
        }
    }
}
