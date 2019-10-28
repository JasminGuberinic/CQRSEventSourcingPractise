using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CQRSAndEventSourcing
{
    public enum OrderStatus
    {
        Processing = 0,
        Pending = 1,
        Completed = 2,
        Cancelled = 3,
    }
}
