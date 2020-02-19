using AutoMapper;
using Venu.Events.Domain;
using Venu.Events.Queries.Dtos;

namespace Venu.Events.Extensions.Converters
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
                        cfg.CreateMap<EventDto, Event>().ReverseMap();
                    });

            Mapper = config.CreateMapper();
        }
    }
}
