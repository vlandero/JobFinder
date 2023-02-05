using Newtonsoft.Json;
using System.Text.Json.Serialization;
using Tema.Migrations;
using Tema.Models.Companies;
using Tema.Models.DTOs.Companies;
using Tema.Models.Users.Seeker;
using Tema.Services.Companies;
using JsonConstructorAttribute = System.Text.Json.Serialization.JsonConstructorAttribute;

namespace Tema.Models.DTOs.Response.Users.Login
{
    public class SeekerResponseLoginDTO : UserResponseLoginDTO<Seeker>
    {
        public CompanyResponseDTO Company { get; set; }

        [JsonConstructor]
        public SeekerResponseLoginDTO() { }

        public SeekerResponseLoginDTO(Seeker s, string Token) : base(s, Token)
        {
            Company = new CompanyResponseDTO(s.Company);
        }
    }
}
