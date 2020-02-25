using System.ComponentModel.DataAnnotations;

namespace Venu.Identity.Dtos
{
    public class RegisterUserDto
    {
        [Required]
        public string FirstName { get; set; }

        [Required]
        public string LastName { get; set; }

        [Required]
        public string Username { get; set; }

        [Required]
        public string Password { get; set; }
        
        [Required]
        public string Role { get; set; }
    }
}