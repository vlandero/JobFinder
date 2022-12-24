using Tema.Models.Users.BaseUser;
using Tema.Models.Users.Seeker;

namespace Tema.Services.Users
{
    public interface IUserService<UserEntity> where UserEntity : User
    {
        Task Create(UserEntity newUser);
        Task<UserEntity> GetByEmail(string email);
        void DeleteAll();
    }
}
