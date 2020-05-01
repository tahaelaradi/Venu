using System.Collections.Generic;
using System.Threading.Tasks;
using Venu.Ticketing.Domain.AggregatesModel.SeatingAggregate;

namespace Venu.Ticketing.API.Infrastructure.Services
{
    public class VenueService : IVenueService
    {
        private readonly ISeatingRepository _seatingRepository;

        public VenueService(ISeatingRepository seatingRepository)
        {
            _seatingRepository = seatingRepository;
        }

        public Task<IEnumerable<Seat>> GetSeatsByVenueId(int id)
        {
            throw new System.NotImplementedException();
        }
    }
}