using System.ComponentModel.DataAnnotations;
using Tema.Models.ManyToMany;
using Tema.Models.Users.BaseUser;

namespace Tema.Models.Users.Finder
{
    public interface IFinder : IUser
    {
        public string? Resume { get; set; }
        [Required]
        public string? About { get; set; }
        [Required]
        public List<Applicant> JobApplications { get; set; }
    }
}
