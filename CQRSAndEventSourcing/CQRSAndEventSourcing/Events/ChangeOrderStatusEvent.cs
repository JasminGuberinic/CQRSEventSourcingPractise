using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CQRSAndEventSourcing
{
    class ChangeOrderStatusEvent : Event
    {
        public CustomerOrder CustomerOrder { get; set; }
        public OrderStatus OldOrderStatus { get; set; }
        public OrderStatus NewOrderStatus { get; set; }

        public ChangeOrderStatusEvent(CustomerOrder customerOrder, OrderStatus oldVlue, OrderStatus newValue)
        {
            CustomerOrder = customerOrder;
            OldOrderStatus = oldVlue;
            NewOrderStatus = newValue;
        }

        public override string ToString()
        {
            return $"Status changed from {OldOrderStatus} to {NewOrderStatus}";
        }
    }
}
