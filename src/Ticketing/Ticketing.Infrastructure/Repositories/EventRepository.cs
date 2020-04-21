using System.Threading.Tasks;
using Venu.Ticketing.Domain.AggregatesModel.EventAggregate;

namespace Venu.Ticketing.Infrastructure.Repositories
{
    public class EventRepository
    {
        private readonly TicketingContext _context;

        public EventRepository(TicketingContext context)
        {
            _context = context;
        }
        
        public async Task Add(Event e)
        {
            _context.Events.Add(e);
            await _context.SaveChangesAsync();
        }
    }
}