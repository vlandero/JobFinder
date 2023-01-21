using System.Text.Json.Serialization;
using Tema.Models.Jobs;

namespace Tema.Models.DTOs.Response.Jobs
{
    public class JobResponseDTO : IJobResponseDTO
    {
        public long PostId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Location { get; set; }
        public string? Category { get; set; }
        public string CreatorEmail { get; set; }
        public string? Salary { get; set; }
        public DateTime? DateCreated { get; set; }

        [JsonConstructor]
        public JobResponseDTO() { }

        public JobResponseDTO(Job j)
        {
            PostId = j.PostId;
            Name = j.Name;
            Description = j.Description;
            Category = j.Category;
            Location = j.Location;
            Salary = j.Salary;
            DateCreated = j.DateCreated;
            CreatorEmail = j.Seeker.Email;
        }
    }
}
