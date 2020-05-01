using Venu.Ticketing.Domain.AggregatesModel.VenueAggregate;
using Venu.Ticketing.Domain.SeedWork;

namespace Venu.Ticketing.Infrastructure.Repositories
{
    public class VenueRepository : IVenueRepository
    {
        private readonly TicketingContext _context;
        
        public IUnitOfWork UnitOfWork
        {
            get { return _context; }
        }
        
        public VenueRepository(TicketingContext context)
        {
            _context = context;
        }
        
        public Venue Add(Venue venue)
        {
            return  _context.Venues.Add(venue).Entity;
        }
    }
}