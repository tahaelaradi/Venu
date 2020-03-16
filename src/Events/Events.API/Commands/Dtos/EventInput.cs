﻿using System;

 namespace Venu.Events.API.Commands.Dtos
{
    public class EventInput
    {
        public string Name { get; set; }
        public string Type { get; set; }
        public string Category { get; set; }
        public string Url { get; set; }
        public string PrimaryOrganizerId { get; set; }
        public string Summary { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public string VenueId { get; set; }
        public string[] Tags { get; set; }
        public bool HasVenue { get; set; }
        public bool IsFree { get; set; }
        public Address Address { get; set; }
        public Image Image { get; set; }
    }
    
    public class Address
    {
        public string City { get; set; }
        public string State { get; set; }
        public string Country { get; set; }
        public string PostalCode { get; set; }
        public string Longitude { get; set; }
        public string Latitude { get; set; }
        public string AddressDisplayName { get; set; }
    }
    
    public class Image
    {
        public string Id { get; set; }
        public string Url { get; set; }
    }
}