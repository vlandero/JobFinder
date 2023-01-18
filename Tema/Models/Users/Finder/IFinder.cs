using System.ComponentModel.DataAnnotations;
using Tema.Models.ManyToMany;
using Tema.Models.Users.BaseUser;

namespace Tema.Models.Users.Finder
{
    public interface IFinder : IUser
    {
        string? Resume { get; set; }
        string? About { get; set; }
        List<string> Skills { get; set; }
        List<Applicant> JobApplications { get; set; }
    }
}
