using System.Text.Json.Serialization;
using Tema.Models.Companies;
using Tema.Models.Jobs;

namespace Tema.Models.DTOs.Applications
{
    public class ApplicationDTO : IApplicationDTO
    {
        public long PostId { get; set; }
        public string CompanyName { get; set; }
        public string JobTitle { get; set; }
        public string? CompanyLogo { get; set; }

        [JsonConstructor]
        public ApplicationDTO() { }

        public ApplicationDTO(Company c, Job j)
        {
            PostId = j.PostId;
            CompanyName = c.Name;
            JobTitle = j.Name;
            CompanyLogo = c.Logo;
        }

    }
}
