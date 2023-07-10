using TicketCinema.Models.DomainModels;
using TicketCinema.Models.DTO;
using TicketCinema.Models.Relations;
using TicketCinema.Repository.Interface;

using TicketCinema.Service.Interface;

namespace TicketCinema.Service.Implementation
{
    public class MovieService : IMovieService
    {
        private readonly IRepository<Movie> _movieRepository;
        private readonly IRepository<MovieInShoppingCart> _movieInShoppingCartRepository;
        private readonly IUserRepository _userRepository;

        public MovieService(IRepository<Movie> movieRepository, IRepository<MovieInShoppingCart> movieInShoppingCartRepository, IUserRepository userRepository)
        {
            _movieRepository = movieRepository;
            _userRepository = userRepository;
            _movieInShoppingCartRepository = movieInShoppingCartRepository;
        }


        public bool AddToShoppingCart(AddToShoppingCartDto item, string userID)
        {
            var user = this._userRepository.Get(userID);

            var userShoppingCard = user.UserCart;

            if (item.SelectedMovieId != null && userShoppingCard != null)
            {
                var product = this.GetDetailsForMovie(item.SelectedMovieId);
                

                if (product != null)
                {
                    MovieInShoppingCart itemToAdd = new MovieInShoppingCart
                    {
                        Id = Guid.NewGuid(),
                        CurrentMovie = product,
                        MovieId = product.Id,
                        UserCart = userShoppingCard,
                        ShoppingCartId = userShoppingCard.Id,
                        Quantity = item.Quantity
                    };

                    var existing = userShoppingCard.MovieInShoppingCarts.Where(z => z.ShoppingCartId == userShoppingCard.Id && z.MovieId == itemToAdd.MovieId).FirstOrDefault();

                    if (existing != null)
                    {
                        existing.Quantity += itemToAdd.Quantity;
                        this._movieInShoppingCartRepository.Update(existing);

                    }
                    else
                    {
                        this._movieInShoppingCartRepository.Insert(itemToAdd);
                    }
                    return true;
                }
                return false;
            }
            return false;
        }

        public void CreateNewMovie(Movie m)
        {
            this._movieRepository.Insert(m);
        }

        public void DeleteMovie(Guid id)
        {
            var product = this.GetDetailsForMovie(id);
            this._movieRepository.Delete(product);
        }

        public List<Movie> GetAllMovies()
        {
            return this._movieRepository.GetAll().ToList();
        }

        public Movie GetDetailsForMovie(Guid? id)
        {
            return this._movieRepository.Get(id);
        }

        public AddToShoppingCartDto GetShoppingCartInfo(Guid? id)
        {
            var product = this.GetDetailsForMovie(id);
            AddToShoppingCartDto model = new AddToShoppingCartDto
            {
                SelectedMovie = product,
                SelectedMovieId = product.Id,
                Quantity = 1
            };

            return model;
        }

        public void UpdeteExistingMovie(Movie m)
        {
            this._movieRepository.Update(m);
        }
    }
}
