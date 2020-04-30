using System.Threading.Tasks;
using Venu.Ticketing.Domain.SeedWork;

namespace Venu.Ticketing.Domain.AggregatesModel.CustomerAggregate
{
    public interface ICustomerRepository : IRepository<Customer>
    {
        Task Add(Customer customer);
        Task<Customer> GetAsync(int customerId);
    }
}