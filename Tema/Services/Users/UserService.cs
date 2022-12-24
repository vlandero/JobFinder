using Tema.Helpers.JwtHelpers;
using Tema.Models.Users.BaseUser;
using Tema.Repositories.UsersRepository.GenericUsersRepository;


namespace Tema.Services.Users
{
    public class UserService<UserEntity> : IUserService<UserEntity> where UserEntity : User
    {
        protected readonly IGenericUsersRepository<UserEntity> _userRepository;
        protected IJwtHelpers<UserEntity> _jwtHelpers;
        public UserService(IGenericUsersRepository<UserEntity> userRepository, IJwtHelpers<UserEntity> jwtHelpers) { 
            _userRepository = userRepository;
            _jwtHelpers = jwtHelpers;
        }
        public UserEntity GetById(Guid id)
        {
            return _userRepository.FindById(id);
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
