
using Tema.Models.Jobs;
using Tema.Models.ManyToMany;
using Tema.Models.Users.BaseUser;

namespace Tema.Models.Users
{
    public class Finder : User
    {
        public string Resume { get; set; }
        public List<Applicant> JobApplications { get; set; }
    }
}
