using System.Linq;

namespace CQRSAndEventSourcing
{
    public class ChangeOrderStatusCommand : Command
    {
        public int CommandId { get; set; }
        public int OrderId { get; set; }
        public OrderStatus OrderStatus { get; set; }
        OrderRepository OrderRepository { get; set; }

        public ChangeOrderStatusCommand(OrderRepository orderRepository, int orderId, OrderStatus orderStatus)
        {
            OrderRepository = orderRepository;
            ChangeOrderStatus(orderStatus, orderId);
        }

        public ChangeOrderStatusCommand(CustomerOrder customerOrder, OrderStatus oldOrderStatus)
        {
            ChangeOrderStatus(oldOrderStatus, customerOrder.Id);
        }

        private void ChangeOrderStatus(OrderStatus orderStatus, int orderId)
        {
            OrderRepository.customerOrders.FirstOrDefault(or => or.Id == orderId);
            OrderStatus = orderStatus;
            OrderId = orderId;
        }
    }
}