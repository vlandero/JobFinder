using System.Text.Json.Serialization;
using Tema.Models.Jobs;

namespace Tema.Models.DTOs.Request.Jobs
{
    public class JobRequestDTO : IJobRequestDTO
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public string Location { get; set; }
        public string? Category { get; set; }
        public string CreatorEmail { get; set; }
        public string? Salary { get; set; }

        [JsonConstructor]
        public JobRequestDTO() { }
        /*
        public JobRequestDTO(Job j)
        {
            Name = j.Name;
            Description = j.Description;
            Category = j.Category;
            Location = j.Location;
            Salary = j.Salary;
        }*/
    }
}
