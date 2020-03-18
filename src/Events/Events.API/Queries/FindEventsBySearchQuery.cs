using System.Collections.Generic;
using MediatR;
using Venu.Events.API.Queries.Dtos;

namespace Venu.Events.API.Queries
{
    public class FindEventsBySearchQuery: IRequest<IEnumerable<EventDto>>
    {
        public string Name;
        public string Category;
    }
}