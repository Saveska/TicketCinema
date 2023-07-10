using TicketCinema.Models.DomainModels;

namespace TicketCinema.Service.Interface
{
    public interface IEmailService
    {
        Task SendEmailAsync(List<EmailMessage> allMails);
    }
}
