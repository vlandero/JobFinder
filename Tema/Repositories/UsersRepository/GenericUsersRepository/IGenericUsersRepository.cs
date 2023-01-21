using Tema.Models.Users.BaseUser;
using Tema.Repositories.GenericRepository;

namespace Tema.Repositories.UsersRepository.GenericUsersRepository
{
    public interface IGenericUsersRepository<UserEntity> : IGenericRepository<UserEntity> where UserEntity : User
    {
        Task<UserEntity> GetByEmailAsync(string email);
        Task<UserEntity> GetByUrlAsync(string url);
    }
}
