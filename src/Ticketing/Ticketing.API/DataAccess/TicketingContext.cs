using Microsoft.EntityFrameworkCore;
using Ticketing.API.Domain;

namespace Ticketing.API.DataAccess
{
    public class TicketingContext : DbContext
    {
        public DbSet<Customer> Customers { get; set; }

        public TicketingContext(DbContextOptions<TicketingContext> options) : base(options)
        {
            System.Diagnostics.Debug.WriteLine("TicketingContext :: ctor => " + this.GetHashCode());
        }
    }
}