using Venu.Ticketing.Domain.AggregatesModel.TicketAggregate;
using Venu.Ticketing.Domain.SeedWork;

namespace Venu.Ticketing.Infrastructure.Repositories
{
    public class TicketRepository : ITicketRepository
    {
        private readonly TicketingContext _context;
        
        public IUnitOfWork UnitOfWork
        {
            get { return _context; }
        }
        
        public TicketRepository(TicketingContext context)
        {
            _context = context;
        }
        
        public Ticket Add(Ticket ticket)
        {
            return  _context.Tickets.Add(ticket).Entity;
        }
    }
}