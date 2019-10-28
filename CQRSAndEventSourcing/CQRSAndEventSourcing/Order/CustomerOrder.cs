namespace CQRSAndEventSourcing
{
    public class CustomerOrder
    {
        public int Id { get; set; }
        private OrderStatus OrderStatus { get; set; }
        public EventBroker EventBroker  { get; set; }

        public CustomerOrder(EventBroker broker)
        {
            EventBroker = broker;
            broker.Commands += BrokerOnCommands;
            broker.Queries += BrokerOnQueries;
        }

        private void BrokerOnQueries(object sender, Query e)
        {
            var statusQuery = e as StatusQuery;
            if (statusQuery != null && statusQuery.customerOrder == this)
            {
                statusQuery.result = OrderStatus;
            }
        }

        private void BrokerOnCommands(object sender, Command command)
        {
            var changeOrderStatus = command as ChangeOrderStatusCommand;
            if (changeOrderStatus != null && changeOrderStatus.OrderId == Id)
            {
                if (changeOrderStatus.register) EventBroker.allEvents.Add(new ChangeOrderStatusEvent(this, OrderStatus, changeOrderStatus.OrderStatus));
                OrderStatus = changeOrderStatus.OrderStatus;
            }
        }
    }
}