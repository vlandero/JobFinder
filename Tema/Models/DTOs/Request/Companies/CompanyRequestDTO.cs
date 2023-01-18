using System.Text.Json.Serialization;
using Tema.Models.Companies;
using Tema.Models.DTOs.Jobs;
using Tema.Models.Jobs;

namespace Tema.Models.DTOs.Companies
{
    public class CompanyRequestDTO : ICompanyRequestDTO
    {
        public string Name { get; set; }
        public string? Description { get; set; }
        public string? Location { get; set; }
        public string? Logo { get; set; }

        [JsonConstructor]
        public CompanyRequestDTO() { }
        

    }
}
