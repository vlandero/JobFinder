using System.ComponentModel.DataAnnotations;
using Tema.Models.Companies;
using Tema.Models.Jobs;
using Tema.Models.Users.BaseUser;

namespace Tema.Models.Users.Seeker
{
    public interface ISeeker : IUser
    {
        [Required]
        public Company Company { get; set; }
        [Required]
        public bool IsCreator { get; set; }
        [Required]
        public List<Job> ListedJobs { get; set; }
    }
}
