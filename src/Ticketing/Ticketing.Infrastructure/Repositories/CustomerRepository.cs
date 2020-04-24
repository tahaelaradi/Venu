using System.Threading.Tasks;
using Venu.Ticketing.Domain.AggregatesModel.CustomerAggregate;
using Venu.Ticketing.Domain.SeedWork;

namespace Venu.Ticketing.Infrastructure.Repositories
{
    public class CustomerRepository : ICustomerRepository
    {
        private readonly TicketingContext _context;

        public IUnitOfWork UnitOfWork
        {
            get { return _context; }
        }
        
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