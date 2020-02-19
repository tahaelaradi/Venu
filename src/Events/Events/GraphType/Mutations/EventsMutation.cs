using Automatonymous;
using GraphQL.Types;
using MediatR;
using Venu.Events.Commands;
using Venu.Events.Commands.Dtos;
using Venu.Events.GraphType.Types;

namespace Venu.Events.GraphType.Mutations
{
    public class EventsMutation : ObjectGraphType
    {
        public EventsMutation(IMediator mediator)
        {
            Name = "Mutation";
            Field<EventType>(
                "createEvent",
                arguments: new QueryArguments(
                    new QueryArgument<NonNullGraphType<EventInputType>> {Name="event"}
                    ),
                resolve: context =>
                {
                    var eventDraft = context.GetArgument<EventDraftDto>("event");
                    var command = new CreateEventDraftCommand()
                    {
                        EventDraft = eventDraft
                    };

                    var result = mediator.Send(command);
                    return result;
                }
            );
        }
    }
}