using Tema.Models.DTOs.Finders;

namespace Tema.Models.DTOs.Response.Jobs
{
    public interface IJobResponseDTO
    {
        long PostId { get; set; }
        string Name { get; set; }
        string Description { get; set; }
        string Location { get; set; }
        string Category { get; set; }
        string CreatorEmail { get; set; }
        string? Salary { get; set; }
        List<FinderDTO> Applicants { get; set; }
        DateTime? DateCreated { get; set; }
    }
}
