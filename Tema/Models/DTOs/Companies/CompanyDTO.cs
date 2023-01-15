using System.Text.Json.Serialization;
using Tema.Models.Companies;
using Tema.Models.DTOs.Jobs;
using Tema.Models.Jobs;

namespace Tema.Models.DTOs.Companies
{
    public class CompanyDTO : ICompanyDTO
    {
        public string Name { get; set; }
        public string? Description { get; set; }
        public string? Location { get; set; }
        public string? Logo { get; set; }
        public List<JobDTO>? ListedJobs { get; set; }

        [JsonConstructor]
        public CompanyDTO() { }
        
        public CompanyDTO(Company c)
        {
            Name = c.Name;
            Description = c.Description;
            Location = c.Location;
            Logo = c.Logo;
        }
        public CompanyDTO(Company c, List<JobDTO> jobs) : this(c)
        {
            ListedJobs = jobs;
        }

    }
}
