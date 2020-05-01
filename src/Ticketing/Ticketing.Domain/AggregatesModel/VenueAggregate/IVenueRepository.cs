using Venu.Ticketing.Domain.SeedWork;

namespace Venu.Ticketing.Domain.AggregatesModel.VenueAggregate
{
    public interface IVenueRepository : IRepository<Venue>
    {
        Venue Add(Venue venue);
    }
}