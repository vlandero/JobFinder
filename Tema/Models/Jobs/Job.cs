using System.ComponentModel.DataAnnotations;
using Tema.Models.Base;
using Tema.Models.ManyToMany;
using Tema.Models.Users.Seeker;

namespace Tema.Models.Jobs
{
    public class Job : BaseEntity, IJob
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public string Location { get; set; }
        public string Category { get; set; }
        public string? Salary { get; set; }
        public Seeker Seeker { get; set; }
        public List<Applicant> Applicants { get; set; }
    }
}
