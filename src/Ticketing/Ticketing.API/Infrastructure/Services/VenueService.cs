using System.Threading.Tasks;
using Venu.Ticketing.API.Application.Queries;

namespace Venu.Ticketing.API.Infrastructure.Services
{
    public class VenueService : IVenueService
    {
        private readonly IVenueQueries _venueQueries;

        public VenueService(IVenueQueries venueQueries)
        {
            _venueQueries = venueQueries;
        }

        public Task<Venue> GetSeatsByVenueId(string id)
        {
            return _venueQueries.GetVenueAsync(id);
        }
    }
}