using System.Collections.Generic;
using Venu.BuildingBlocks.Shared.Messaging;
using VenueSection = Venu.Events.API.Models.Section;
using VenueInputSection = Venu.Events.API.ViewModel.Section;

namespace Venu.Events.API.Infrastructure.Extensions.Converters
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
        
        public static IEnumerable<VenueSectionsCreated> ToVenueSectionsCreated(this IEnumerable<VenueSection> venueSections)
        {
            foreach (var venueSection in venueSections)
            {
                yield return venueSection.ToVenueSectionCreated();
            }
        }

        public static VenueSectionsCreated ToVenueSectionCreated(this VenueSection venueSection)
        {
            return new VenueSectionsCreated()
            {
                Ordinal = venueSection.Ordinal,
                Price = venueSection.Price
            };
        }
    }
}