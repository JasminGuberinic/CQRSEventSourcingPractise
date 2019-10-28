using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CQRSAndEventSourcing
{
    class StatusQuery : Query
    {
        public CustomerOrder customerOrder;
    }
}
