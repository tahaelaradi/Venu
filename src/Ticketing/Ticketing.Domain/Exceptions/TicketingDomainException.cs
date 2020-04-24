using System;

namespace Venu.Ticketing.Domain.Exceptions
{
    public class TicketingDomainException : Exception
    {
        public TicketingDomainException()
        {
        }

        public TicketingDomainException(string message) : base(message)
        {
        }
    }
}