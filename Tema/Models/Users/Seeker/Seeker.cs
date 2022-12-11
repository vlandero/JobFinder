using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
using Tema.Models.Base;
using Tema.Models.Companies;
using Tema.Models.Enums;
using Tema.Models.Jobs;
using Tema.Models.Users.BaseUser;

namespace Tema.Models.Users.Seeker
{
    public class Seeker : User, ISeeker
    {
        public Company Company { get; set; }
        public Company? CompanyCreated { get; set; }
        public List<Job> ListedJobs { get; set; }
    }
}
