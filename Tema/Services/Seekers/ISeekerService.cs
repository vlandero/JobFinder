using Tema.Models.DTOs.Request.Users.Login;
using Tema.Models.DTOs.Response.Users.Login;
using Tema.Models.Users.Seeker;
using Tema.Services.Users;

namespace Tema.Services.Seekers
{
    public interface ISeekerService : IUserService<Seeker>
    {
        Task<SeekerResponseLoginDTO> Login(UserRequestLoginDTO user);
        Task<Seeker> GetByIdWithCompanyId(Guid id);
        Task<Seeker> GetByUrlWithCOmpanyId(string url);
    }
}
