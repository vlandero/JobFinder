using Microsoft.EntityFrameworkCore;
using Tema.Models;
using Tema.Models.Users.BaseUser;
using Tema.Repositories.GenericRepository;

namespace Tema.Repositories.UsersRepository.GenericUsersRepository
{
    public class GenericUsersRepository<UserEntity> : GenericRepository<UserEntity>, IGenericUsersRepository<UserEntity> where UserEntity : User
    {
        public GenericUsersRepository(MyAppContext context) : base(context)
        {

        }
        public Task<UserEntity> GetByEmailAsync(string email)
        {

            return _table.FirstOrDefaultAsync<UserEntity>(u => u.Email == email);

        }
    }
}
