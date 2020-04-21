using Microsoft.EntityFrameworkCore;
using Venu.Ticketing.Domain.AggregatesModel.CustomerAggregate;
using Venu.Ticketing.Domain.AggregatesModel.EventAggregate;

namespace Venu.Ticketing.Infrastructure
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