using System.ComponentModel.DataAnnotations;

namespace Tema.Models.DTOs.Request.Users.Register
{
    public class UserRequestRegisterDTO
    {
        [Required]
        public string Email { get; set; }
        [Required]
        public string Password { get; set; }
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }
        [Required]
        public string Url { get; set; }
    }
}
