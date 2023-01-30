using Tema.Helpers.JwtHelpers;
using Tema.Models.Users.BaseUser;
using Tema.Repositories.GenericRepository;
using Tema.Repositories.UsersRepository.GenericUsersRepository;
using Tema.Services.Generic;

namespace Tema.Services.Users
{
    public class UserService<UserEntity> : GenericService<UserEntity>, IUserService<UserEntity> where UserEntity : User
    {
        protected readonly IGenericUsersRepository<UserEntity> _userRepository;
        protected IJwtHelpers<UserEntity> _jwtHelpers;
        public UserService(IGenericRepository<UserEntity> repository, IGenericUsersRepository<UserEntity> userRepository, IJwtHelpers<UserEntity> jwtHelpers) : base(repository)
        { 
            _userRepository = userRepository;
            _jwtHelpers = jwtHelpers;
        }
        public async Task<UserEntity> GetByEmail(string email)
        {
            return await _userRepository.GetByEmailAsync(email);
        }
        public async Task <UserEntity> GetByUrl(string url)
        {
            return await _userRepository.GetByUrlAsync(url);
        }
    }
}
