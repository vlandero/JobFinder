using Tema.Models.DTOs.Request.Users.Login;
using Tema.Models.DTOs.Response.Users.Login;
using Tema.Models.Users.Seeker;
using Tema.Services.Users;

namespace Tema.Services.Seekers
{
    public interface ISeekerService : IUserService<Seeker>
    {
        public Task<SeekerResponseLoginDTO> Login(UserRequestLoginDTO user);
    }
}
