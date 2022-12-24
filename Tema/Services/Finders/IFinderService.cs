using Tema.Models.DTOs.Request.Users.Login;
using Tema.Models.DTOs.Response.Users.Login;
using Tema.Models.Users.Finder;
using Tema.Services.Users;

namespace Tema.Services.Finders
{
    public interface IFinderService : IUserService<Finder>
    {
        public Task<FinderResponseLoginDTO> Login(UserRequestLoginDTO user);
    }
}
