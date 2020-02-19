using GraphQL.Types;
using MediatR;
using Venu.Events.GraphType.Types;
using Venu.Events.Queries;

namespace Venu.Events.GraphType.Queries
{
    public class EventsQuery : ObjectGraphType
    {
        public EventsQuery(IMediator mediator)
        {
            Field<ListGraphType<EventType>>(
                "events",
                resolve: context => mediator.Send(new FindAllEventsQuery())
            );
        }
    }
}