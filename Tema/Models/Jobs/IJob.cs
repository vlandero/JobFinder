using System.ComponentModel.DataAnnotations;
using Tema.Models.Base;
using Tema.Models.Companies;
using Tema.Models.ManyToMany;
using Tema.Models.Users.Seeker;

namespace Tema.Models.Jobs
{
    public interface IJob : IBaseEntity
    {
        [Required]
        public string Name { get; set; }
        [Required]
        public string Description { get; set; }
        [Required]
        public string Location { get; set; }
        public string Category { get; set; }
        public string? Salary { get; set; }
        [Required]
        public Seeker Seeker { get; set; }
        [Required]
        public List<Applicant> Applicants { get; set; }
    }
}

