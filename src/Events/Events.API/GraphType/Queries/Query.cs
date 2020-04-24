using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using MediatR;
using Venu.Events.API.Queries;
using Venu.Events.API.Queries.Dtos;

namespace Venu.Events.API.GraphType.Queries
{
    public class Query
    {
        private readonly IMediator _mediator;

        public Query(IMediator mediator)
        {
            _mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
        }

        public async Task<IEnumerable<EventDto>> GetEvents()
        {
            return await _mediator.Send(new FindAllEventsQuery());
        }

        public async Task<EventDto> GetEventById(string id)
        {
            return await _mediator.Send(new FindEventQuery{ Id = id });
        }
        
        public async Task<IEnumerable<EventDto>> GetEventsBySearch(string name, string category)
        {
            return await _mediator.Send(new FindEventsBySearchQuery
            {
                Name = name,
                Category = category
            });
        }
    }
}