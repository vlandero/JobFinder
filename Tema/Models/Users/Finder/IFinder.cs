using System.ComponentModel.DataAnnotations;
using Tema.Models.ManyToMany;
using Tema.Models.Users.BaseUser;

namespace Tema.Models.Users.Finder
{
    public interface IFinder : IUser
    {
        public string? Resume { get; set; }
        public string? About { get; set; }
        public List<Applicant> JobApplications { get; set; }
    }
}
