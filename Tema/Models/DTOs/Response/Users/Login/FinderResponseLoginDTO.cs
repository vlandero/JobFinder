using Tema.Models.Users.Finder;

namespace Tema.Models.DTOs.Response.Users.Login
{
    public class FinderResponseLoginDTO : UserResponseLoginDTO<Finder>
    {
        
        public string? Resume { get; set; }
        public string? About { get; set; }

        public FinderResponseLoginDTO(Finder f, string Token) : base(f, Token)
        {
            Resume = f.Resume;
            About = f.About;
        }
    }
}
