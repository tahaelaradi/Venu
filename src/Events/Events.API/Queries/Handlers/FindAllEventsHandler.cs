using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Venu.Events.API.Infrastructure.Extensions.Converters;
using Venu.Events.API.Models;
using Event = Venu.Events.API.ViewModel.Event;

namespace Venu.Events.API.Queries.Handlers
{
    public class FindAllEventsHandler : IRequestHandler<FindAllEventsQuery, IEnumerable<Event>>
    {
        private readonly IRepository _eventRepository;
        
        public FindAllEventsHandler(IRepository eventRepository)
        {
            _eventRepository = eventRepository ?? throw new ArgumentNullException(nameof(eventRepository));            
        }

        public async Task<IEnumerable<Event>> Handle(FindAllEventsQuery request,  CancellationToken cancellationToken)
        {
            var result = await _eventRepository.GetAllAsync<Models.Event>(e => true);
            return result.Select(e => e.ToDto());
        }
    }
}