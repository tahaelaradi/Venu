using System.Threading.Tasks;
using Venu.Ticketing.Domain.AggregatesModel.CustomerAggregate;

namespace Venu.Ticketing.Infrastructure.Repositories
{
    public class CustomerRepository
    {
        private readonly TicketingContext _context;

        public CustomerRepository(TicketingContext context)
        {
            _context = context;
        }
        
        public async Task Add(Customer customer)
        {
            _context.Customers.Add(customer);
            await _context.SaveChangesAsync();
        }
    }
}