using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Venu.Ticketing.Domain.AggregatesModel.CustomerAggregate;
using Venu.Ticketing.Domain.AggregatesModel.EventAggregate;
using Venu.Ticketing.Domain.AggregatesModel.SeatingAggregate;
using Venu.Ticketing.Domain.AggregatesModel.TicketAggregate;
using Venu.Ticketing.Domain.AggregatesModel.VenueAggregate;
using Venu.Ticketing.Domain.SeedWork;

namespace Venu.Ticketing.Infrastructure
{
    public class TicketingContext : DbContext, IUnitOfWork
    {
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Event> Events { get; set; }
        public DbSet<Venue> Venues { get; set; }

        public DbSet<Section> Sections { get; set; }
        public DbSet<Seat> Seats { get; set; }
        public DbSet<Ticket> Tickets { get; set; }

        private readonly IMediator _mediator;
        
        public TicketingContext(DbContextOptions<TicketingContext> options, IMediator mediator) : base(options)
        {
            _mediator = mediator;
            System.Diagnostics.Debug.WriteLine("TicketingContext :: ctor => " + this.GetHashCode());
        }
        
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
        }
        
        public async Task<bool> SaveEntitiesAsync(CancellationToken cancellationToken = default(CancellationToken))
        {
            await _mediator.DispatchDomainEventsAsync(this);
            await base.SaveChangesAsync(cancellationToken);
            return true;
        }
    }
}