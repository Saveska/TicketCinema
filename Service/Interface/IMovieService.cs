using TicketCinema.Models.DomainModels;
using TicketCinema.Models.DTO;

namespace TicketCinema.Service.Interface
{
    public interface IMovieService
    {
      
            List<Movie> GetAllMovies();
            Movie GetDetailsForMovie(Guid? id);
            void CreateNewMovie(Movie p);
            void UpdeteExistingMovie(Movie p);
            AddToShoppingCartDto GetShoppingCartInfo(Guid? id);
            void DeleteMovie(Guid id);
            bool AddToShoppingCart(AddToShoppingCartDto item, string userID);
    }

}
