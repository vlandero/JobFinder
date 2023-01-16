using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Tema.Models.Base;
using Tema.Models.ManyToMany;
using Tema.Models.Users.Seeker;

namespace Tema.Models.Jobs
{
    public interface IJob : IBaseEntity
    {
        string Name { get; set; }
        string Description { get; set; }
        string Location { get; set; }
        string? Category { get; set; }
        string? Salary { get; set; }
        Seeker Seeker { get; set; }
        List<Applicant> Applicants { get; set; }
        long PostId { get; set; }
        
    }
}

