using Tema.Models.Jobs;
using Tema.Models.Users.Finder;

namespace Tema.Models.ManyToMany
{
    public class Applicant
    {
        public Guid FinderId { get; set; }
        public Finder Finder { get; set; }
        
        public Guid JobId { get; set; }
        public Job Job { get; set; }
    }
}
