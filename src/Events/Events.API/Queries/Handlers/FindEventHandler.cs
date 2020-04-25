using System;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Venu.Events.API.Infrastructure.Exceptions;
using Venu.Events.API.Infrastructure.Extensions.Converters;
using Venu.Events.API.Models;
using Event = Venu.Events.API.ViewModel.Event;

namespace Venu.Events.API.Queries.Handlers
{
    public class FindEventHandler : IRequestHandler<FindEventQuery, Event>
    {
        private readonly IRepository _eventRepository;
        
        public FindEventHandler(IRepository eventRepository)
        {
            _eventRepository = eventRepository ?? throw new ArgumentNullException(nameof(eventRepository));            
        }
        
        public async Task<Event> Handle(FindEventQuery request,  CancellationToken cancellationToken)
        {
            try
            {
                var result = await _eventRepository.GetByIdAsync<Models.Event>(request.Id);
                if (result == null)
                    throw SecurityException.NotFound("event", request.Id);

                return result.ToDto();
            }
            catch (FormatException)
            {
                throw SecurityException.NotFound("event", request.Id);
            }
        }
    }
}