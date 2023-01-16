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
        [Required]
        public Company Company { get; set; }
        [Required]
        public bool IsCreator { get; set; }
        [Required]
        public List<Job> ListedJobs { get; set; }
    }
}
