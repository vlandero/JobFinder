using Tema.Models.DTOs.Companies;
using Tema.Models.Users.Seeker;

namespace Tema.Models.DTOs.Response.Users.Login
{
    public class SeekerResponseLoginDTO : UserResponseLoginDTO<Seeker>
    {
        public CompanyDTO Company { get; set; }

        public SeekerResponseLoginDTO(Seeker s, string Token) : base(s, Token)
        {
            Company = new CompanyDTO(s.Company);
        }
    }
}
