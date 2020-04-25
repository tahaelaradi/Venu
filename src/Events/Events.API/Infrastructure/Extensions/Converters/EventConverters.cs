using Event = Venu.Events.API.ViewModel.Event;
using EventAddress = Venu.Events.API.Models.Address;
using EventImage = Venu.Events.API.Models.Image;
using EventInputAddress = Venu.Events.API.ViewModel.Address;
using EventInputImage = Venu.Events.API.ViewModel.Image;

namespace Venu.Events.API.Infrastructure.Extensions.Converters
{
    public static class EventConverters
    {
        public static Models.Event ToContract(this Event @event)
        {
            return AutoMapperConfiguration.Mapper.Map<Models.Event>(@event);
        }
        
        public static Event ToDto(this Models.Event Event)
        {
            return AutoMapperConfiguration.Mapper.Map<Event>(Event);
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