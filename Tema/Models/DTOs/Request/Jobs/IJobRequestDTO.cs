namespace Tema.Models.DTOs.Request.Jobs
{
    public interface IJobRequestDTO
    {
        string Name { get; set; }
        string Description { get; set; }
        string Location { get; set; }
        string Category { get; set; }
        string? Salary { get; set; }
        string CreatorEmail { get; set; }
    }
}
