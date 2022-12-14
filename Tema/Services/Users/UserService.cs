using Tema.Helpers.JwtHelpers;
using Tema.Models.DTOs.Request.Users.Login;
using Tema.Models.DTOs.Response.Users.Login;
using Tema.Models.Users.BaseUser;
using Tema.Repositories.GenericRepository;
using Tema.Repositories.UsersRepository.GenericUsersRepository;
using Tema.Services.Generic;

namespace Tema.Services.Users
{
    public class UserService<UserEntity> : GenericService<User>, IUserService<UserEntity> where UserEntity : User
    {
        protected readonly IGenericUsersRepository<UserEntity> _userRepository;
        protected IJwtHelpers<UserEntity> _jwtHelpers;
        public UserService(IGenericRepository<User> repository, IGenericUsersRepository<UserEntity> userRepository, IJwtHelpers<UserEntity> jwtHelpers) : base(repository)
        { 
            _userRepository = userRepository;
            _jwtHelpers = jwtHelpers;
        }
        public async Task<UserEntity> GetByEmail(string email)
        {
            return await _userRepository.GetByEmailAsync(email);
        }
    }
}
