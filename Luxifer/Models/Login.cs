using System.ComponentModel.DataAnnotations;

namespace Luxifer.Models
{
    public class Login
    {
        [Required(ErrorMessage = "Introduza o email")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Introduza a password")]
        public string Password { get; set; }
    }
}
