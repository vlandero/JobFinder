using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
using Tema.Models.Base;
using Tema.Models.Enums;

namespace Tema.Models.Users.BaseUser
{
    public class User : BaseEntity, IUser
    {
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }
        [Required]
        public string Email { get; set; }
        [Required]
        [JsonIgnore]
        public string PasswordHash { get; set; }
        public string? ProfilePicture { get; set; }
        [Required]
        public string Url { get; set; }
        [Required]
        public Role Role { get; set; }
    }
}
