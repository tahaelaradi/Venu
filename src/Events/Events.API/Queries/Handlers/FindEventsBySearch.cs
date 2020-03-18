using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Venu.Events.API.Domain;
using Venu.Events.API.Extensions.Converters;
using Venu.Events.API.Helpers;
using Venu.Events.API.Queries.Dtos;

namespace Venu.Events.API.Queries.Handlers
{
    public class FindEventsBySearch : IRequestHandler<FindEventsBySearchQuery, IEnumerable<EventDto>>
    {
        private readonly IRepository _eventRepository;
        
        public FindEventsBySearch(IRepository eventRepository)
        {
            _eventRepository = eventRepository ?? throw new ArgumentNullException(nameof(eventRepository));            
        }

        public async Task<IEnumerable<EventDto>> Handle(FindEventsBySearchQuery request,  CancellationToken cancellationToken)
        {
            var filterContainer = new FilterContainer<Event>();
            
            if (request.Name != null)
                filterContainer.AddFilterCondition(p => p.Name == request.Name);
            
            if (request.Category != null)
                filterContainer.AddFilterCondition(p => p.Category == request.Category);
            
            var filter = filterContainer.GetFilter();

            var result = await _eventRepository.GetAllAsync(filter);
            return result.Select(e => e.ToDto());
        }
    }
}