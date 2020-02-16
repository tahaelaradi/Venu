using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Venu.Events.Domain;

namespace Venu.Events.Commands.Handlers
{
    public class CreateEventDraftHandler : IRequestHandler<CreateEventDraftCommand, CreateEventDraftResult>
    {
        private readonly IRepository _eventRepository;

        public CreateEventDraftHandler(IRepository eventRepository)
        {
            this._eventRepository = eventRepository;
        }

        public async Task<CreateEventDraftResult> Handle(CreateEventDraftCommand request, CancellationToken cancellationToken)
        {
            var draft = Event.CreateDraft
            (
                request.EventDraft.Name
            );

            await _eventRepository.AddOneAsync(draft);

            return new CreateEventDraftResult
            {
                EventId = draft.Id
            };
        }
    }
}