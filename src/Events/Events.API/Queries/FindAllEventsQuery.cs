using System.Collections.Generic;
using MediatR;
using Venu.Events.API.ViewModel;

namespace Venu.Events.API.Queries
{
    public class FindAllEventsQuery : IRequest<IEnumerable<Event>>
    {
        
    }
}