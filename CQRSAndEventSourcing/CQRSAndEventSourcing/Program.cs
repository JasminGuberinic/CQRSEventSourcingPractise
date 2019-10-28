using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CQRSAndEventSourcing
{
    class Program
    {
        static void Main(string[] args)
        {
            EventBroker eventBroker = new EventBroker();
            OrderRepository orderRepository = new OrderRepository(eventBroker);

            eventBroker.Command(new ChangeOrderStatusCommand(orderRepository, 1, OrderStatus.Pending));
            foreach (var e in eventBroker.allEvents)
            {
                Console.WriteLine(e);
            }

            Console.ReadKey();
        }
    }
}
