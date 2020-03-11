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
            _mediator = mediator;
        }
        
        public async Task<IEnumerable<EventDto>> GetEvents()
        {
            return await _mediator.Send(new FindAllEventsQuery());
        }
    }
}