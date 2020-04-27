using Venu.Ticketing.Domain.AggregatesModel.SeatingAggregate;
using Venu.Ticketing.Domain.SeedWork;

namespace Venu.Ticketing.Infrastructure.Repositories
{
    public class SeatingRepository : ISeatingRepository
    {
        private readonly TicketingContext _context;

        public IUnitOfWork UnitOfWork
        {
            get { return _context; }
        }
        
        public SeatingRepository(TicketingContext context)
        {
            _context = context;
        }
        
        public Seat Add(Seat seat)
        {
            return  _context.Seats.Add(seat).Entity;
        }
    }
}