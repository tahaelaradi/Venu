using GraphQL.Types;
using MediatR;
using Venu.Events.API.GraphType.Types;

namespace Venu.Events.API.GraphType.Queries
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