using Microsoft.EntityFrameworkCore;
using Venu.Ticketing.API.Domain;

namespace Venu.Ticketing.API.DataAccess
{
    public class TicketingContext : DbContext
    {
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Event> Events { get; set; }

        public TicketingContext(DbContextOptions<TicketingContext> options) : base(options)
        {
            System.Diagnostics.Debug.WriteLine("TicketingContext :: ctor => " + this.GetHashCode());
        }
    }
}