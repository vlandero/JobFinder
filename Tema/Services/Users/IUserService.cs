using Tema.Models.Users.BaseUser;
using Tema.Services.Generic;

namespace Tema.Services.Users
{
    public interface IUserService<UserEntity> : IGenericService<UserEntity> where UserEntity : User
    {
        Task<UserEntity> GetByEmail(string email);
        Task<UserEntity> GetByUrl(string url);

    }
}
