using Tema.Models.Users.BaseUser;

namespace Tema.Models.DTOs.Users
{
    public interface IUsersDTO<T> where T : User
    {
        string Email { get; set; }
        string FirstName { get; set; }
        string LastName { get; set; }
        string Url { get; set; }
        string ProfilePicture { get; set; }
    }
}
