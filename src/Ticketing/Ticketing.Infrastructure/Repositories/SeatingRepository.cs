using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Venu.Ticketing.Domain.AggregatesModel.SeatingAggregate;
using Venu.Ticketing.Domain.SeedWork;

namespace Venu.Ticketing.Infrastructure.Repositories
{
    public class SeatingRepository : ISeatingRepository
    {
        private readonly TicketingContext _context;

        public IUnitOfWork UnitOfWork
        {
            get { return _context; }
        }
        
        public SeatingRepository(TicketingContext context)
        {
            _context = context;
        }
        
        public Seat Add(Seat seat)
        {
            return  _context.Seats.Add(seat).Entity;
        }
        
        public async Task<Seat> GetAsync(int seatId)
        {
            var seat = await _context
                .Seats
                .FirstOrDefaultAsync(s => s.Id == seatId);
            
            if (seat == null)
            {
                seat = _context
                    .Seats
                    .Local.FirstOrDefault(s => s.Id == seatId);
            }
            
            return seat;
        }
        
        public void Update(Seat seat)
        {
            _context.Entry(seat).State = EntityState.Modified;
        }
    }
}