using TicketCinema.Models.Relations;

namespace TicketCinema.Models.Identity

{
    public class ShoppingCart : BaseEntity
    {
        public string OwnerId { get; set; }
        public virtual TicketCinemaAppUser Owner { get; set; }

        public virtual ICollection<MovieInShoppingCart> MovieInShoppingCarts { get; set; }

    }
}
