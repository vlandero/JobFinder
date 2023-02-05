using Newtonsoft.Json;
using Tema.Helpers.JwtHelpers;
using Tema.Migrations;
using Tema.Models.DTOs.Request.Users.Login;
using Tema.Models.DTOs.Response.Users.Login;
using Tema.Models.DTOs.Seekers;
using Tema.Models.Users.Seeker;
using Tema.Repositories.CompaniesRepository;
using Tema.Repositories.GenericRepository;
using Tema.Repositories.UsersRepository;
using Tema.Services.Users;
using BCryptNet = BCrypt.Net.BCrypt;

namespace Tema.Services.Seekers
{
    public class SeekerService : UserService<Seeker>, ISeekerService
    {
        private readonly ISeekersRepository _seekersRepository;
        public SeekerService(ISeekersRepository seekersRepository, IGenericRepository<Seeker> repo,ISeekersRepository userRepository, IJwtHelpers<Seeker> jwtHelpers) : base(repo, userRepository, jwtHelpers)
        {
            _seekersRepository = seekersRepository;
        }
        public async Task<SeekerResponseLoginDTO> Login(UserRequestLoginDTO user)
        {
            System.Diagnostics.Debug.WriteLine("hello1");

            var u = await _seekersRepository.GetByEmailWithCompanyId(user.Email);
            System.Diagnostics.Debug.WriteLine("hello2");
            if (u == null || !BCryptNet.Verify(user.Password, u.PasswordHash))
            {
                throw new Exception("Invalid email or password");
            }
            var jwtToken = _jwtHelpers.GenerateJwtToken(u);
            return new SeekerResponseLoginDTO(u, jwtToken);
        }
        public async Task<Seeker> GetByIdWithCompanyId(Guid id)
        {
            var x = await _seekersRepository.GetByIdWithCompanyId(id);
            return x;
        }
        public async Task<Seeker> GetByUrlWithCOmpanyId(string url)
        {
            var x = await _seekersRepository.GetByUrlWithCompanyId(url);
            return x;

        }

    }

}
