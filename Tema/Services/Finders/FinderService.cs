using Tema.Helpers.JwtHelpers;
using Tema.Models.DTOs.Request.Users.Login;
using Tema.Models.DTOs.Response.Users.Login;
using Tema.Models.Users.BaseUser;
using Tema.Models.Users.Finder;
using Tema.Repositories.GenericRepository;
using Tema.Repositories.UsersRepository.FindersRepository;
using Tema.Services.Users;
using BCryptNet = BCrypt.Net.BCrypt;

namespace Tema.Services.Finders
{
    public class FinderService : UserService<Finder>, IFinderService
    {

        public FinderService(IGenericRepository<Finder> repo, IFindersRepository userRepository, IJwtHelpers<Finder> jwtHelpers) : base(repo, userRepository, jwtHelpers)
        {
        }
        public async Task<FinderResponseLoginDTO> Login(UserRequestLoginDTO user)
        {
            var u = await _userRepository.GetByEmailAsync(user.Email);
            if (u == null || !BCryptNet.Verify(user.Password, u.PasswordHash))
            {
                throw new Exception("Invalid email or password");
            }
            var jwtToken = _jwtHelpers.GenerateJwtToken(u);
            return new FinderResponseLoginDTO(u, jwtToken);
        }

    }
}
