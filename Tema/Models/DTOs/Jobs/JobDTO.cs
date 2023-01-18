using System.Text.Json.Serialization;
using Tema.Models.Jobs;

namespace Tema.Models.DTOs.Jobs
{
    public class JobDTO : IJobDTO
    {
        public long? PostId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Category { get; set; }
        public string Location { get; set; }
        public string? CreatorEmail { get; set; }
        public string? Salary { get; set; }

        [JsonConstructor]
        public JobDTO() { }

        public JobDTO(Job j)
        {
            PostId = j.PostId;
            Name = j.Name;
            Description = j.Description;
            Category = j.Category;
            Location = j.Location;
            Salary = j.Salary;
        }

    }
}
