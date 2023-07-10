using TicketCinema.Models.DTO;

namespace TicketCinema.Service.Interface
{
    public interface IShoppingCartService
    {
        ShoppingCartDto getShoppingCartInfo(string userId);
        bool deleteMovieFromShoppingCart(string userId, Guid movieId);
        bool order(string userId);
    }
}
