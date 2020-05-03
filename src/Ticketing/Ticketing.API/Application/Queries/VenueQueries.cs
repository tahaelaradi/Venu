using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Dapper;
using Npgsql;

namespace Venu.Ticketing.API.Application.Queries
{
    public class VenueQueries : IVenueQueries
    {
        private string _connectionString;

        public VenueQueries(string constr)
        {
            _connectionString = !string.IsNullOrWhiteSpace(constr) ? constr : throw new ArgumentNullException(nameof(constr));
        }

        public async Task<Venue> GetVenueAsync(string id)
        {
            using (var connection = new NpgsqlConnection(_connectionString))
            {
                connection.Open();

                var seats = await connection.QueryAsync<Seat>(
                    $@"SELECT sc.""Ordinal"" as ordinal, s.""Id"" as seatId, s.""Row"" as row, s.""Column"" as column,
                            sc.""Price"" as price, s.""IsOccupied"" as isSeatOccupied 
                        FROM venu_ticketing.public.venues v
                        LEFT JOIN sections sc on v.""Id"" = sc.""VenueId""
                        LEFT JOIN seats s on sc.""Id"" = s.""SectionId""
                        WHERE v.""Id""=@id",
                    new { id }
                    );

                if (seats.AsList().Count == 0) throw new KeyNotFoundException();

                var mappedResult = MapSeats(id, seats);
                return mappedResult;
            }
        }

        private Venue MapSeats(string venueId, IEnumerable<Seat> seats)
        {
            var venue = new Venue(venueId)
            {
                seats = seats.ToList()
            };

            return venue;
        }
    }
}