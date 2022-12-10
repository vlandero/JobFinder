using Tema.Models.Users.BaseUser;
using Tema.Repositories.UsersRepository.GenericUsersRepository;

namespace Tema.Services.Users
{
    public class UserService<UserEntity> : IUserService<UserEntity> where UserEntity : User
    {
        public IGenericUsersRepository<UserEntity> _userRepository;
        public UserService(IGenericUsersRepository<UserEntity> userRepository){
            _userRepository = userRepository;
        }
        public async Task Create(UserEntity newUser)
        {
            await _userRepository.CreateAsync(newUser);
            await _userRepository.SaveAsync();
        }
    }
}
