using System;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Venu.Ticketing.Domain.AggregatesModel.CustomerAggregate;
using Venu.Ticketing.Domain.AggregatesModel.EventAggregate;
using Venu.Ticketing.Domain.SeedWork;

namespace Venu.Ticketing.Infrastructure
{
    public class TicketingContext : DbContext, IUnitOfWork
    {
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Event> Events { get; set; }
        public DbSet<VenueSection> VenueSections { get; set; }

        private readonly IMediator _mediator;
        
        public TicketingContext(DbContextOptions<TicketingContext> options) : base(options)
        {
            System.Diagnostics.Debug.WriteLine("TicketingContext :: ctor => " + this.GetHashCode());
        }
        
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            var guidToStringConverter =
                new ValueConverter<string, Guid>(
                    v => new Guid(v),
                    v => v.ToString());

            modelBuilder
                .Entity<VenueSection>(
                    entityTypeBuilder => { entityTypeBuilder.Property(e => e.Id).HasConversion(guidToStringConverter); });
        }
        
        public async Task<bool> SaveEntitiesAsync(CancellationToken cancellationToken = default(CancellationToken))
        {
            await _mediator.DispatchDomainEventsAsync(this);
            var result = await base.SaveChangesAsync(cancellationToken);
            return true;
        }
    }
}