using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Serilog;
using Venu.Ticketing.Domain.AggregatesModel.EventAggregate;
using Venu.Ticketing.Domain.AggregatesModel.VenueAggregate;
using Venu.Ticketing.Infrastructure.Repositories;

namespace Venu.Ticketing.API.Application.Commands
{
    public class CreateEventHandler : IRequestHandler<CreateEventCommand>
    {
        private readonly IEventRepository _eventRepository;
        private readonly IVenueRepository _venueRepository;
        
        public CreateEventHandler(IEventRepository eventRepository, IVenueRepository venueRepository)
        {
            _eventRepository = eventRepository;
            _venueRepository = venueRepository;
        }
        
        public async Task<Unit> Handle(CreateEventCommand message, CancellationToken cancellationToken)
        {
            Log.Information($"Creating Event: {message.Name}");
            var e = new Event(message.EventId, message.Name);
            
            _eventRepository.Add(e);
            await _eventRepository.UnitOfWork.SaveEntitiesAsync(cancellationToken);

            var venue = new Venue(message.VenueId, message.EventId);
            foreach (var section in message.VenueSections.ToList())
            {
                venue.AddSection(venue.Id, section.Ordinal, section.Price, section.Rows, section.Columns);
            }

            _venueRepository.Add(venue);
            await _venueRepository.UnitOfWork.SaveEntitiesAsync(cancellationToken);
            
            return Unit.Value;
        }
    }
}