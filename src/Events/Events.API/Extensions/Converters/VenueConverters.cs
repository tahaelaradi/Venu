using System.Collections.Generic;
using VenueSection = Venu.Events.API.Domain.Section;
using VenueInputSection = Venu.Events.API.Commands.Dtos.Section;

namespace Venu.Events.API.Extensions.Converters
{
    public static class VenueConverters
    {
        public static VenueSection ToContract(this VenueInputSection sectionDto)
        {
            return AutoMapperConfiguration.Mapper.Map<VenueSection>(sectionDto);
        }
        
        public static List<VenueSection> ToContract(this List<VenueInputSection> sectionsDto)
        {
            return AutoMapperConfiguration.Mapper.Map<List<VenueInputSection>, List<VenueSection>>(sectionsDto);
        }    
    }
}