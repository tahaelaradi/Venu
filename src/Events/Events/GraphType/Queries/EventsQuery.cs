using GraphQL.Types;
using MediatR;
using Venu.Events.GraphType.Types;
using Venu.Events.Queries;

namespace Venu.Events.GraphType.Queries
{
    public class EventsQuery : ObjectGraphType
    {
        private readonly Query _query;

        public EventsQuery(IMediator mediator)
        {
            _query = new Query(mediator);
            
            Field<ListGraphType<EventType>>(
                "events",
                resolve: context => _query.GetEvents()
            );
        }
    }
}