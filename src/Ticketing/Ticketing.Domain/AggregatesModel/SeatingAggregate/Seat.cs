using System;
using System.ComponentModel.DataAnnotations.Schema;
using Venu.Ticketing.Domain.SeedWork;

namespace Venu.Ticketing.Domain.AggregatesModel.SeatingAggregate
{
    [Table("Seat")]
    public class Seat : Entity, IAggregateRoot
    {
        public string VenueSectionId { get; set; }
        public int Row { get; set; }
        public int Column { get; set; }
        
        public bool IsOccupied { get; set; }
        
        public DateTime CreatedOn { get; set; }
        public DateTime UpdateOn { get; set; }

        public Seat(string venueSectionId, int row, int column)
        {
            VenueSectionId = venueSectionId;
            Row = row;
            Column = column;
            IsOccupied = false;
            CreatedOn = DateTime.Now;
        }
    }
}