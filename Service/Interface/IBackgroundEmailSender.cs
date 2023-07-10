namespace TicketCinema.Service.Interface
{
    public interface IBackgroundEmailSender
    {
        Task DoWork();
    }
}
