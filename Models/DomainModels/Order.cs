using TicketCinema.Models.Identity;
using TicketCinema.Models.Relations;
using System;

namespace TicketCinema.Models.DomainModels
{
    public class Order : BaseEntity
    {
        public string UserId { get; set; }
        public TicketCinemaAppUser User { get; set; }

        public virtual ICollection<MovieInOrder> MovieInOrders { get; set; }
    }
}
