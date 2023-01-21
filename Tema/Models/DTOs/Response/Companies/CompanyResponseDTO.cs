using System.Text.Json.Serialization;
using Tema.Models.Companies;
using Tema.Models.DTOs.Response.Jobs;

namespace Tema.Models.DTOs.Companies
{
    public class CompanyResponseDTO : ICompanyResponseDTO
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public string Location { get; set; }
        public string? Logo { get; set; }
        public List<JobResponseDTO>? ListedJobs { get; set; }

        [JsonConstructor]
        public CompanyResponseDTO() { }
        
        public CompanyResponseDTO(Company c)
        {
            Name = c.Name;
            Description = c.Description;
            Location = c.Location;
            Logo = c.Logo;
        }
        public CompanyResponseDTO(Company c, List<JobResponseDTO> jobs) : this(c)
        {
            ListedJobs = jobs;
        }

    }
}
