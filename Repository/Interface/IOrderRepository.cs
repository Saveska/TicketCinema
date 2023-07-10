using TicketCinema.Models.DomainModels;
using TicketCinema.Models;


namespace TicketCinema.Repository.Interface
{
    public interface IOrderRepository
    {
        public List<Order> getAllOrders();
        public Order getOrderDetails(BaseEntity model);
    }
}
