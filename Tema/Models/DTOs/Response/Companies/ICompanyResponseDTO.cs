using Tema.Models.DTOs.Response.Jobs;

namespace Tema.Models.DTOs.Companies
{
    public interface ICompanyResponseDTO
    {
        string Name { get; set; }
        string Description { get; set; }
        string Location { get; set; }
        string? Logo { get; set; }
        List<JobResponseDTO> ListedJobs { get; set; }
    }
}
