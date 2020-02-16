using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Venu.Events.Domain;
using Venu.Events.Queries.Dtos;

namespace Venu.Events.Queries.Handlers
{
    public class FindAllEventsHandler : IRequestHandler<FindAllEventsQuery, IEnumerable<EventDto>>
    {
        private readonly IRepository _eventRepository;
        
        public FindAllEventsHandler(IRepository eventRepository)
        {
            this._eventRepository = eventRepository ?? throw new ArgumentNullException(nameof(eventRepository));            
        }

        public async Task<IEnumerable<EventDto>> Handle(FindAllEventsQuery request,  CancellationToken cancellationToken)
        {
            var result = await _eventRepository.GetAllAsync<Event>(e => true);
            return result.Select(e => new EventDto()
            {
                Name = e.Name
            }).ToList();
        }
    }
}