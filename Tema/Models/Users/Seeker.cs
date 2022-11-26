using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
using Tema.Models.Base;
using Tema.Models.Companies;
using Tema.Models.Enums;
using Tema.Models.Jobs;
using Tema.Models.Users.BaseUser;

namespace Tema.Models.Users
{
    public class Seeker : User
    {
        [Required]
        public Company Company { get; set; }
        public List<Job> Jobs { get; set; }
    }
}
