using Tema.Helpers.JwtHelpers;
using Tema.Models.DTOs.Request.Users.Login;
using Tema.Models.DTOs.Response.Users.Login;
using Tema.Models.Users.BaseUser;
using Tema.Models.Users.Seeker;
using Tema.Repositories.GenericRepository;
using Tema.Repositories.UsersRepository;
using Tema.Services.Users;
using BCryptNet = BCrypt.Net.BCrypt;

namespace Tema.Services.Seekers
{
    public class SeekerService : UserService<Seeker>, ISeekerService
    {
        public SeekerService(IGenericRepository<User> repo,ISeekersRepository userRepository, IJwtHelpers<Seeker> jwtHelpers) : base(repo, userRepository, jwtHelpers)
        {
        }
        public async Task<SeekerResponseLoginDTO> Login(UserRequestLoginDTO user)
        {
            var u = await _userRepository.GetByEmailAsync(user.Email);
            if (u == null || !BCryptNet.Verify(user.Password, u.PasswordHash))
            {
                throw new Exception("Invalid email or password");
            }
            var jwtToken = _jwtHelpers.GenerateJwtToken(u);
            return new SeekerResponseLoginDTO(u, jwtToken);
        }
        
    }

}
