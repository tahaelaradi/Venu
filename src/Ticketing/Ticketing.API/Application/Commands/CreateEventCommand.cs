using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using MediatR;
using Venu.BuildingBlocks.Shared.Messaging;
using Venu.Ticketing.API.Extensions.Converters;

namespace Venu.Ticketing.API.Application.Commands
{
    [DataContract]
    public class CreateEventCommand : IRequest
    {
        [DataMember] 
        private readonly List<VenueSectionsInput> _venueSections;

        [DataMember] 
        public string EventId { get; set; }
        
        [DataMember] 
        public string VenueId { get; set; }

        [DataMember] 
        public string Name { get; set; }
        
        [DataMember] 
        public IEnumerable<VenueSectionsInput> VenueSections => _venueSections;
        
        public CreateEventCommand()
        {
            _venueSections = new List<VenueSectionsInput>();
        }

        public CreateEventCommand(string eventId, string venueId, string name, List<VenueSectionsCreated> venueSections) : this()
        {
            EventId = eventId;
            VenueId = venueId;
            Name = name;
            _venueSections = venueSections.ToVenueSectionsInput().ToList();
        }
    }

    public class VenueSectionsInput
    {
        public string VenueId { get; set; }
        public int Ordinal { get; set; }
        public double Price { get; set; }
    }
}