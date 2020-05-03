using System;
using System.ComponentModel.DataAnnotations.Schema;
using Venu.Ticketing.Domain.SeedWork;

namespace Venu.Ticketing.Domain.AggregatesModel.SeatingAggregate
{
    [Table("seats")]
    public class Seat : Entity, IAggregateRoot
    {
        public string SectionId { get; set; }
        public int Row { get; set; }
        public int Column { get; set; }
        
        public bool IsOccupied { get; set; }
        
        public DateTime CreatedOn { get; set; }
        public DateTime UpdateOn { get; set; }

        public Seat(string sectionId, int row, int column)
        {
            SectionId = sectionId;
            Row = row;
            Column = column;
            IsOccupied = false;
            CreatedOn = DateTime.Now;
        }

        public void SetIsOccupied(bool value)
        {
            IsOccupied = value;
        }
    }
}