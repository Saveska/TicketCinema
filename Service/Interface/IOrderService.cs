using TicketCinema.Models.DomainModels;
using TicketCinema.Models;

namespace TicketCinema.Service.Interface
{
    public interface IOrderService
    {
        public List<Order> getAllOrders();
        public Order getOrderDetails(BaseEntity model);
    }

}
