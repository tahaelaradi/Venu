using System.Collections.Generic;
using MediatR;
using Venu.Events.API.Queries.Dtos;

namespace Venu.Events.API.Queries
{
    public class FindAllEventsQuery : IRequest<IEnumerable<EventDto>>
    {
        
    }
}