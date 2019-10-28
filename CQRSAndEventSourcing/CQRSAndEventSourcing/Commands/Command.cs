using System;

namespace CQRSAndEventSourcing
{
    public class Command : EventArgs
    {
        public bool register = true;
    }
}