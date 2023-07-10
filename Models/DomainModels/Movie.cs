using System.ComponentModel.DataAnnotations;
using TicketCinema.Models.DomainModels;
using TicketCinema.Models.Relations;
using System;

namespace TicketCinema.Models.DomainModels
{
    public class Movie : BaseEntity
    {
        [Required]
        public string MovieName { get; set; }
        [Required]
        public string MovieImage { get; set; }
        [Required]
        public string MovieDescription { get; set; }
        [Required]
        public double MoviePrice { get; set; }
        [Required]
        public double MovieRating { get; set; }


        public virtual ICollection<MovieInShoppingCart> MovieInShoppingCarts { get; set; }
        public virtual ICollection<MovieInOrder> MovieInOrders { get; set; }

    }
}
