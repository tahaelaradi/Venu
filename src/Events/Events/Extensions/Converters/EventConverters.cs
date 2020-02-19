using Venu.Events.Domain;
using Venu.Events.Queries.Dtos;

namespace Venu.Events.Extensions.Converters
{
    public static class EventConverters
    {
        public static Event ToContract(this EventDto eventDto)
        {
            return AutoMapperConfiguration.Mapper.Map<Event>(eventDto);
        }
        
        public static EventDto ToDto(this Event Event)
        {
            return AutoMapperConfiguration.Mapper.Map<EventDto>(Event);
        }
    }
}