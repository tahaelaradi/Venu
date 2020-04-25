using AutoMapper;
using Event = Venu.Events.API.ViewModel.Event;
using EventAddress = Venu.Events.API.Models.Address;
using EventInputAddress = Venu.Events.API.ViewModel.Address;
using VenueSections = Venu.Events.API.Models.Section;
using VenueInputSections = Venu.Events.API.ViewModel.Section;

namespace Venu.Events.API.Infrastructure.Extensions.Converters
{
    /// <summary>
    /// AutoMapper configuration
    /// </summary>
    public class AutoMapperConfiguration
    {
        /// <summary>
        /// Mapper
        /// </summary>
        public static IMapper Mapper { get; set; }

        static AutoMapperConfiguration()
        {
            var config =
                new MapperConfiguration(
                    cfg =>
                    {
                        cfg.CreateMap<Event, Models.Event>().ReverseMap();
                        cfg.CreateMap<EventInputAddress, EventAddress>();
                        cfg.CreateMap<VenueInputSections, VenueSections>();
                    });

            Mapper = config.CreateMapper();
        }
    }
}
