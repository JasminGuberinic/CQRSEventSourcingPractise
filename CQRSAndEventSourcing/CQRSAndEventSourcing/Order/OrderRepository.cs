using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CQRSAndEventSourcing
{
    public class OrderRepository
    {
        public List<CustomerOrder> customerOrders { get; set; }

         public OrderRepository(EventBroker eventBroker)
        {
            customerOrders = new List<CustomerOrder>()
            {
                new CustomerOrder(eventBroker){ Id = 1 },
                new CustomerOrder(eventBroker){ Id = 2 },
                new CustomerOrder(eventBroker){ Id = 3 }
            };
        }
    }
}
