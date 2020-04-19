using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Serilog;
using Venu.Ticketing.API.DataAccess.Repositories;
using Venu.Ticketing.API.Domain;
using Venu.Ticketing.API.Queries.Dtos;

namespace Venu.Ticketing.API.Commands.Handlers
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