using Venu.Ticketing.Domain.SeedWork;

namespace Venu.Ticketing.Domain.AggregatesModel.SeatingAggregate
{
    public interface ISeatingRepository : IRepository<Seat>
    {
        Seat Add(Seat seat);
    }
}