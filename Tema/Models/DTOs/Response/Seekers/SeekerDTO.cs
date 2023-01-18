using System.Text.Json.Serialization;
using Tema.Models.DTOs.Companies;
using Tema.Models.DTOs.Jobs;
using Tema.Models.DTOs.Users;
using Tema.Models.Users.Seeker;

namespace Tema.Models.DTOs.Seekers
{
    public class SeekerDTO : UsersDTO<Seeker>, ISeekerDTO
    {
        public bool IsCreator { get; set; }
        public CompanyResponseDTO Company { get; set; }
        public List<JobDTO> ListedJobs { get; set; }
        [JsonConstructor]
        public SeekerDTO() : base() { }

        public SeekerDTO(Seeker s, List<JobDTO> listedJobs) : base(s)
        {
            IsCreator = s.IsCreator;
            Company = new CompanyResponseDTO(s.Company);
            ListedJobs = listedJobs;
        }
    }
}
