using Venu.Ticketing.Domain.SeedWork;

namespace Venu.Ticketing.Domain.AggregatesModel.TicketAggregate
{
    public interface ITicketRepository : IRepository<Ticket>
    {
        Ticket Add(Ticket ticket);
    }
}