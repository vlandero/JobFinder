using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
using Tema.Models.Enums;

namespace Tema.Models.Users.BaseUser
{
    public interface IUser
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string? ProfilePicture { get; set; }
        public string Email { get; set; }
        public string Url { get; set; }
        public string PasswordHash { get; set; }
        public Role Role { get; set; }
    }
}
