using System.ComponentModel.DataAnnotations;
using Tema.Models.Companies;
using Tema.Models.Jobs;
using Tema.Models.Users.BaseUser;

namespace Tema.Models.Users.Seeker
{
    public interface ISeeker : IUser
    {
        public Company? Company { get; set; }
        public bool IsCreator { get; set; }
        public List<Job>? ListedJobs { get; set; }
    }
}
