using System;
using System.Collections.Generic;

namespace Venu.Events.API.ViewModel
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
        public string[] Tags { get; set; }
        public bool IsFree { get; set; }
        public Venue Venue { get; set; }
        public Address Address { get; set; }
        public Image Image { get; set; }
    }

    public class Image
    {
        public string Id { get; set; }
        public string Url { get; set; }
    }
    
    public class Venue
    {
        public string Name { get; set; }
        public List<Section> Sections { get; set; }
    }

    public class Section
    {
        public int Ordinal { get; set; }
        public int Rows { get; set; }
        public int Columns { get; set; }
        public double Price { get; set; }
    }
}