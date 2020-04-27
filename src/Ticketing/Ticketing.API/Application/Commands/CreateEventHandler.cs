using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Serilog;
using Venu.Ticketing.Domain.AggregatesModel.EventAggregate;
using Venu.Ticketing.Infrastructure.Repositories;

namespace Venu.Ticketing.API.Application.Commands
{
    public class CreateEventHandler : IRequestHandler<CreateEventCommand>
    {
        private readonly IEventRepository _eventRepository;
        
        public CreateEventHandler(IEventRepository eventRepository)
        {
            _eventRepository = eventRepository;
        }
        
        public async Task<Unit> Handle(CreateEventCommand message, CancellationToken cancellationToken)
        {
            Log.Information($"Creating Event: {message.Name}");
            var e = new Event(message.EventId, message.Name);
            
            foreach (var section in message.VenueSections.ToList())
            {
                e.AddVenueSection(message.VenueId, section.Ordinal, section.Price, section.Rows, section.Columns);
            }
            
            _eventRepository.Add(e);
            await _eventRepository.UnitOfWork.SaveEntitiesAsync(cancellationToken);
            return Unit.Value;
        }
    }
}