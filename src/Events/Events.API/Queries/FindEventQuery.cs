using MediatR;
using Venu.Events.API.ViewModel;

namespace Venu.Events.API.Queries
{
    public class FindEventQuery: IRequest<Event>
    {
        public string Id;
    }
}