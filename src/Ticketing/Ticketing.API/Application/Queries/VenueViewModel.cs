using System.Collections.Generic;

namespace Venu.Ticketing.API.Application.Queries
{
    public class Venue
    {
        public Venue(string venueId)
        {
            this.venueId = venueId;
            this.seats = new List<Seat>();
        }

        public string venueId { get; set; }
        public List<Seat> seats { get; set; }
    }

    public class Seat
    {
        public int ordinal { get; set; }
        public int seatId { get; set; }
        public int row { get; set; }
        public int column { get; set; }
        public double price { get; set; }
        public bool isOccupied { get; set; }
    }
}