using Tema.Models.Users.BaseUser;
using Tema.Services.Generic;

namespace Tema.Services.Users
{
    public interface IUserService<UserEntity> : IGenericService<User> where UserEntity : User
    {
        Task<UserEntity> GetByEmail(string email);

    }
}
