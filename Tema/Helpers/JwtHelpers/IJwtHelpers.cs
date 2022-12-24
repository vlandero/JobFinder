using Tema.Models.Users.BaseUser;

namespace Tema.Helpers.JwtHelpers
{
    public interface IJwtHelpers<T> where T : User
    {
        public string GenerateJwtToken(T user);
        public Guid ValidateJwtToken(string token);
    }
}
