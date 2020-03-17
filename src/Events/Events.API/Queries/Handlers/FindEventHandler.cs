using System;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Venu.Events.API.Domain;
using Venu.Events.API.Exceptions;
using Venu.Events.API.Extensions.Converters;
using Venu.Events.API.Queries.Dtos;

namespace Venu.Events.API.Queries.Handlers
{
    public class FindEventHandler : IRequestHandler<FindEventQuery, EventDto>
    {
        private readonly IRepository _eventRepository;
        
        public FindEventHandler(IRepository eventRepository)
        {
            _eventRepository = eventRepository ?? throw new ArgumentNullException(nameof(eventRepository));            
        }
        
        public async Task<EventDto> Handle(FindEventQuery request,  CancellationToken cancellationToken)
        {
            try
            {
                var e = await _eventRepository.GetByIdAsync<Event>(request.Id);
                if (e == null)
                    throw SecurityException.NotFound("event", request.Id);

                return e.ToDto();
            }
            catch (FormatException)
            {
                throw SecurityException.NotFound("event", request.Id);
            }
        }
    }
}