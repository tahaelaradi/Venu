using Venu.Events.API.Domain;
using Venu.Events.API.Queries.Dtos;
using EventAddress = Venu.Events.API.Domain.Address;
using EventImage = Venu.Events.API.Domain.Image;
using EventInputAddress = Venu.Events.API.Commands.Dtos.Address;
using EventInputImage = Venu.Events.API.Commands.Dtos.Image;

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

        public static EventAddress ToContract(this EventInputAddress addressDto)
        {
            return AutoMapperConfiguration.Mapper.Map<EventAddress>(addressDto);
        }
        
        public static EventImage ToContract(this EventInputImage imageDto)
        {
            return AutoMapperConfiguration.Mapper.Map<EventImage>(imageDto);
        }
    }
}