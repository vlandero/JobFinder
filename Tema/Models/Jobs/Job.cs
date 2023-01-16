using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Tema.Models.Base;
using Tema.Models.ManyToMany;
using Tema.Models.Users.Seeker;

namespace Tema.Models.Jobs
{
    public class Job : BaseEntity, IJob
    {
        [Required]
        public string Name { get; set; }
        [Required]
        public string Description { get; set; }
        [Required]
        public string Location { get; set; }
        public string? Category { get; set; }
        public string? Salary { get; set; }
        public Seeker Seeker { get; set; }
        [Required]
        public List<Applicant> Applicants { get; set; }
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long PostId { get; set; }
    }
}
