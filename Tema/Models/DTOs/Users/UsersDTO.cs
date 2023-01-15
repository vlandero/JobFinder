using System.Text.Json.Serialization;
using Tema.Models.Users.BaseUser;

namespace Tema.Models.DTOs.Users
{
    public class UsersDTO<T> : IUsersDTO<T> where T : User
    {
        public string Email { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string ProfilePicture { get; set; }

        [JsonConstructor]
        public UsersDTO() { }

        public UsersDTO(T user){
            Email = user.Email;
            FirstName = user.FirstName;
            LastName = user.LastName;
            ProfilePicture = user.ProfilePicture;
        }
    }
}
