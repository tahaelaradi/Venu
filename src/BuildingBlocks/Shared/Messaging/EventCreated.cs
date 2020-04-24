using System.Collections.Generic;

namespace Venu.BuildingBlocks.Shared.Messaging
{
    public interface EventCreated
    {
        string EventId { get; set; }
        string VenueId { get; set; }
        string Name { get; }
        List<VenueSectionsCreated> VenueSections { get; set; }
    }

    public class VenueSectionsCreated
    {
        public int Ordinal { get; set; }
        public double Price { get; set; }
    }
}
