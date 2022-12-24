using Tema.Models.Users.BaseUser;
using Tema.Models.Users.Seeker;
using Tema.Repositories.UsersRepository.GenericUsersRepository;

namespace Tema.Services.Users
{
    public class UserService<UserEntity> : IUserService<UserEntity> where UserEntity : User
    {
        private readonly IGenericUsersRepository<UserEntity> _userRepository;
        public UserService(IGenericUsersRepository<UserEntity> userRepository){
            _userRepository = userRepository;
        }
        public async Task<UserEntity> GetByEmail(string email)
        {
            return await _userRepository.GetByEmailAsync(email);
        }
        public async Task Create(UserEntity newUser)
        {
            await _userRepository.CreateAsync(newUser);
            await _userRepository.SaveAsync();
        }
        public void DeleteAll()
        {
            _userRepository.DeleteAll();
            _userRepository.Save();
        }
    }
}
