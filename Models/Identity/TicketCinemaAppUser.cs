using TicketCinema.Models.DomainModels;
using Microsoft.AspNetCore.Identity;

namespace TicketCinema.Models.Identity
{
    public class TicketCinemaAppUser : IdentityUser
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Address { get; set; }

        public virtual ShoppingCart UserCart { get; set; }
    }
}
