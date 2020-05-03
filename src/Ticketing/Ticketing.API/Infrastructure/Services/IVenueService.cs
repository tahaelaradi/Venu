using System.Threading.Tasks;
using Venu.Ticketing.API.Application.Queries;

namespace Venu.Ticketing.API.Infrastructure.Services
{
    public interface IVenueService
    {
        Task<Venue> GetSeatsByVenueId(string id);
    }
}