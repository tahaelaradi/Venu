using Venu.Ticketing.Domain.SeedWork;

namespace Venu.Ticketing.Domain.AggregatesModel.EventAggregate
{
    public interface IEventRepository : IRepository<Event>
    {
        Event Add(Event e);
    }
}