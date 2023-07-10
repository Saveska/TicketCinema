using TicketCinema.Models.DomainModels;
using System;
using TicketCinema.Models.Identity;

namespace TicketCinema.Models.Relations
{
    public class MovieInShoppingCart : BaseEntity
    {
        public Guid MovieId { get; set; }
        public virtual Movie CurrentMovie { get; set; }

        public Guid ShoppingCartId { get; set; }
        public virtual ShoppingCart UserCart { get; set; }

        public int Quantity { get; set; }
    }
}
