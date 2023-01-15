namespace Tema.Models.DTOs.Jobs
{
    public interface IJobDTO
    {
        Guid? Id { get; set; }
        string Name { get; set; }
        string Description { get; set; }
        string Location { get; set; }
        string Category { get; set; }
        string CreatorEmail { get; set; }
        string? Salary { get; set; }
    }
}
