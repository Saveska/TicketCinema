using TicketCinema.Models.Identity;
namespace TicketCinema.Repository.Interface
   
{
    public interface IUserRepository
    {
        IEnumerable<TicketCinemaAppUser> GetAll();
        TicketCinemaAppUser Get(string id);
        void Insert(TicketCinemaAppUser entity);
        void Update(TicketCinemaAppUser entity);
        void Delete(TicketCinemaAppUser entity);
    }
}
