using TicketCinema.Models.Relations;

namespace TicketCinema.Models.DTO
{
    public class ShoppingCartDto
    {
        public List<MovieInShoppingCart> Movies { get; set; }

        public double TotalPrice { get; set; }
    }
}
