using System.Collections.Generic;
using MediatR;
using Venu.Events.API.ViewModel;

namespace Venu.Events.API.Queries
{
    public class FindEventsBySearchQuery: IRequest<IEnumerable<Event>>
    {
        public string Name;
        public string Category;
    }
}