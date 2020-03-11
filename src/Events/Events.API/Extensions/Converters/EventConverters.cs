using Venu.Events.API.Domain;
using Venu.Events.API.Queries.Dtos;

namespace Venu.Events.API.Extensions.Converters
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