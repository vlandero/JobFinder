using System.Text.Json.Serialization;
using Tema.Models.Users.BaseUser;

namespace Tema.Models.DTOs.Response.Users.Login
{
    public class UserResponseLoginDTO<T> where T : User
    { 
        public string Email { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Url { get; set; }
        public string? ProfilePicture { get; set; }
        public string? Token { get; set; }
        [JsonConstructor]
        public UserResponseLoginDTO() { }
        
        public UserResponseLoginDTO(T user, string token)
        {
            Email = user.Email;
            FirstName = user.FirstName;
            LastName = user.LastName;
            ProfilePicture = user.ProfilePicture;
            Token = token;
            Url = user.Url;
        }
    }
}
