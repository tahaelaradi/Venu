using System.Collections.Generic;
using System.Threading.Tasks;
using Venu.Ticketing.Domain.AggregatesModel.SeatingAggregate;

namespace Venu.Ticketing.API.Infrastructure.Services
{
    public interface IVenueService
    {
        Task<IEnumerable<Seat>> GetSeatsByVenueId(int id);
    }
}