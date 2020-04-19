using System.ComponentModel.DataAnnotations.Schema;

namespace Venu.Ticketing.API.Domain
{
    [Table("Customer")]
    public class Customer
    {
        public int Id { get; set; }
        public string Username { get; set; }
    }
}