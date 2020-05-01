using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Serilog;
using Venu.Ticketing.Domain.AggregatesModel.SeatingAggregate;
using Venu.Ticketing.Domain.Events;

namespace Venu.Ticketing.API.Application.DomainEventHandlers.SectionCreated
{
    public class AddSeatingAggregateWhenSectionCreatedDomainEventHandler : INotificationHandler<SectionCreatedDomainEvent>
    {
        private readonly ISeatingRepository _seatingRepository;

        public AddSeatingAggregateWhenSectionCreatedDomainEventHandler(ISeatingRepository seatingRepository)
        {
            _seatingRepository = seatingRepository;
        }

        public async Task Handle(SectionCreatedDomainEvent sectionCreatedEvent, CancellationToken cancellationToken)
        {
            Log.Information($"SectionCreatedDomainEvent happened...");
            for (var i = 1; i <= sectionCreatedEvent.Rows; i++)
            {
                for (var j = 1; j <= sectionCreatedEvent.Columns; j++)
                {
                    _seatingRepository.Add(new Seat(sectionCreatedEvent.SectionId, i, j));
                }
            }
            
            await _seatingRepository.UnitOfWork.SaveEntitiesAsync(cancellationToken);
        }
    }
}