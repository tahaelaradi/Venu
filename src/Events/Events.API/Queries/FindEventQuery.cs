using MediatR;
using Venu.Events.API.Queries.Dtos;

namespace Venu.Events.API.Queries
{
    public class FindEventQuery: IRequest<EventDto>
    {
        public string Id;
    }
}