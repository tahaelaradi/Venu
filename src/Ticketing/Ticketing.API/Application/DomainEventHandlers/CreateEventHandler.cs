using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Serilog;
using Venu.Ticketing.API.Application.Commands;
using Venu.Ticketing.Domain.AggregatesModel.EventAggregate;
using Venu.Ticketing.Infrastructure.Repositories;

namespace Venu.Ticketing.API.Application.DomainEventHandlers
{
    public class CreateEventHandler : IRequestHandler<CreateEventCommand>
    {
        private readonly EventRepository _eventRepository;
        
        public CreateEventHandler(EventRepository eventRepository)
        {
            _eventRepository = eventRepository;
        }
        
        public async Task<Unit> Handle(CreateEventCommand request, CancellationToken cancellationToken)
        {
            var e = new Event(request.EventInput.Id, request.EventInput.Name);
            Log.Information($"Creating Event: {e.Name}");
            
            await _eventRepository.Add(e);
            return Unit.Value;
        }
    }
}