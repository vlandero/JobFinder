using Tema.Models.Users.Seeker;

namespace Tema.Models.DTOs.Companies
{
    public interface ICompanyDTO
    {
        public string Name { get; set; }
        public string? Description { get; set; }
        public string? Location { get; set; }
        public string? Logo { get; set; }
    }
}
