using Tema.Models.Users.BaseUser;

namespace Tema.Services.Users
{
    public interface IUserService<UserEntity> where UserEntity : User
    {
        Task Create(UserEntity newUser);
        UserEntity GetById(Guid id);
        Task<UserEntity> GetByEmail(string email);
        void DeleteAll();
    }
}
