
using TicketCinema.Models.DomainModels;

namespace TicketCinema.Models.DTO
{
    public class AddToShoppingCartDto
    {
        public Movie SelectedMovie { get; set; }
        public Guid SelectedMovieId { get; set; }
        public int Quantity { get; set; }
    }
}
