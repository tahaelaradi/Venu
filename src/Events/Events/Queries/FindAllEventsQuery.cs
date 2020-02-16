using System.Collections.Generic;
using MediatR;
using Venu.Events.Queries.Dtos;

namespace Venu.Events.Queries
{
    public class FindAllEventsQuery : IRequest<IEnumerable<EventDto>>
    {
        
    }
}