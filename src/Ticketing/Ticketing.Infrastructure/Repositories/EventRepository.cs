using System.Threading.Tasks;
using Venu.Ticketing.Domain.AggregatesModel.EventAggregate;
using Venu.Ticketing.Domain.SeedWork;

namespace Venu.Ticketing.Infrastructure.Repositories
{
    public class EventRepository : IEventRepository
    {
        private readonly TicketingContext _context;

        public IUnitOfWork UnitOfWork
        {
            get { return _context; }
        }

        public EventRepository(TicketingContext context)
        {
            _context = context;
        }

        public Event Add(Event e)
        {
            return  _context.Events.Add(e).Entity;
        }
    }
}