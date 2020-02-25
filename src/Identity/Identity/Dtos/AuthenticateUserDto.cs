using System.ComponentModel.DataAnnotations;

namespace Venu.Identity.Dtos
{
    public class AuthenticateUserDto
    {
        [Required]
        public string Username { get; set; }

        [Required]
        public string Password { get; set; }
    }
}