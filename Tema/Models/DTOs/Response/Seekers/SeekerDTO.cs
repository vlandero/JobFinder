using System.Text.Json.Serialization;
using Tema.Models.DTOs.Companies;
using Tema.Models.DTOs.Response.Jobs;
using Tema.Models.DTOs.Users;
using Tema.Models.Users.Seeker;

namespace Tema.Models.DTOs.Seekers
{
    public class SeekerDTO : UsersDTO<Seeker>, ISeekerDTO
    {
        public bool IsCreator { get; set; }
        public CompanyResponseDTO Company { get; set; }
        public List<JobResponseDTO> ListedJobs { get; set; }
        [JsonConstructor]
        public SeekerDTO() : base() { }

        public SeekerDTO(Seeker s, List<JobResponseDTO> listedJobs) : base(s)
        {
            IsCreator = s.IsCreator;
            Company = new CompanyResponseDTO(s.Company);
            ListedJobs = listedJobs;
        }
    }
}
