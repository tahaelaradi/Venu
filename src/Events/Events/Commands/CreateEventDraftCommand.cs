using MediatR;
using Venu.Events.Commands.Dtos;

namespace Venu.Events.Commands
{
    public class CreateEventDraftCommand : IRequest<CreateEventDraftResult>
    {
        public EventDraftDto EventDraft { get; set; }
    }
}