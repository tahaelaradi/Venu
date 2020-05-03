using System.Threading.Tasks;

namespace Venu.Ticketing.API.Application.Queries
{
    public interface IVenueQueries
    {
        Task<Venue> GetVenueAsync(string id);
    }
}