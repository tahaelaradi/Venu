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
            Field<EventType>(
                "event",
                arguments: new QueryArguments(
                    new QueryArgument<IdGraphType> { Name = "id" }
                ),
                resolve: context =>
                {
                    var id = context.GetArgument<string>("id");
                    return _query.GetEvent(id);
                }
            );
        }
    }
}