using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Venu.Events.API.Infrastructure.Extensions.Converters;
using Venu.Events.API.Infrastructure.Helpers;
using Venu.Events.API.Models;
using Event = Venu.Events.API.ViewModel.Event;

namespace Venu.Events.API.Queries.Handlers
{
    public class FindEventsBySearch : IRequestHandler<FindEventsBySearchQuery, IEnumerable<Event>>
    {
        private readonly IRepository _eventRepository;
        
        public FindEventsBySearch(IRepository eventRepository)
        {
            _eventRepository = eventRepository ?? throw new ArgumentNullException(nameof(eventRepository));            
        }

        public async Task<IEnumerable<Event>> Handle(FindEventsBySearchQuery request,  CancellationToken cancellationToken)
        {
            var filterContainer = new FilterContainer<Models.Event>();
            
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