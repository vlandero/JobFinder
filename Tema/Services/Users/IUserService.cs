using Tema.Models.Users.BaseUser;

namespace Tema.Services.Users
{
    public interface IUserService<UserEntity> where UserEntity : User
    {
        Task Create(UserEntity newUser);
    }
}
