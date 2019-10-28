using System;
using System.Collections.Generic;
using System.Linq;

namespace CQRSAndEventSourcing
{
    public class EventBroker
    {
        public IList<Event> allEvents = new List<Event>();
        public event EventHandler<Command> Commands;
        public event EventHandler<Query> Queries;

        public void Command(Command command)
        {
            Commands?.Invoke(this, command);
        }

        public T Query<T>(Query q)
        {
            Queries?.Invoke(this, q);
            return (T)q.result;
        }

        public void UndoLast()
        {
            var ev = allEvents.LastOrDefault();
            var changeOrderStatusEvent = ev as ChangeOrderStatusEvent;
            if (changeOrderStatusEvent != null)
            {
                Command(new ChangeOrderStatusCommand(changeOrderStatusEvent.CustomerOrder, changeOrderStatusEvent.OldOrderStatus) { register = false });
                allEvents.Remove(ev);
            }
        }
    }
}