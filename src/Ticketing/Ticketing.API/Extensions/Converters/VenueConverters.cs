using System.Collections.Generic;
using Venu.BuildingBlocks.Shared.Messaging;
using Venu.Ticketing.API.Application.Commands;

namespace Venu.Ticketing.API.Extensions.Converters
{
    public static class VenueConverters
    {
        public static IEnumerable<VenueSectionsInput> ToVenueSectionsInput(this IEnumerable<VenueSectionsCreated> venueSectionsCreated)
        {
            foreach (var venueSection in venueSectionsCreated)
            {
                yield return venueSection.ToVenueSectionInput();
            }
        }

        public static VenueSectionsInput ToVenueSectionInput(this VenueSectionsCreated venueSection)
        {
            return new VenueSectionsInput()
            {
                Ordinal = venueSection.Ordinal,
                Price = venueSection.Price,
                Rows = venueSection.Rows,
                Columns = venueSection.Columns
            };
        }
    }
}