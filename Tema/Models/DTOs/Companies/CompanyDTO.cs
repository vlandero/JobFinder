using Tema.Models.Companies;

namespace Tema.Models.DTOs.Companies
{
    public class CompanyDTO : ICompanyDTO
    {
        public string Name { get; set; }
        public string? Description { get; set; }
        public string? Location { get; set; }
        public string? Logo { get; set; }
        
        public CompanyDTO(Company c)
        {
            Name = c.Name;
            Description = c.Description;
            Location = c.Location;
            Logo = c.Logo;
        }
    }
}
