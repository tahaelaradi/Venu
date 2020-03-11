using GraphQL.Types;
using MediatR;
using Venu.Events.API.Commands.Dtos;
using Venu.Events.API.GraphType.Types;

namespace Venu.Events.API.GraphType.Mutations
{
    public class EventsMutation : ObjectGraphType
    {
        private readonly Mutation _mutation;
        public EventsMutation(IMediator mediator)
        {
            _mutation = new Mutation(mediator);
            
            Name = "Mutation";
            Field<EventType>(
                "createEvent",
                arguments: new QueryArguments(
                    new QueryArgument<NonNullGraphType<EventInputType>> {Name="event"}
                    ),
                resolve: context =>
                {
                    var eventInput = context.GetArgument<EventInput>("event");
                    return _mutation.CreateNewEvent(eventInput);
                }
            );
        }
    }
}