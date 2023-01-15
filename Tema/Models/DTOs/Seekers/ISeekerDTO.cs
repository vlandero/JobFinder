using Tema.Models.DTOs.Companies;
using Tema.Models.DTOs.Jobs;
using Tema.Models.DTOs.Users;
using Tema.Models.Users.Seeker;

namespace Tema.Models.DTOs.Seekers
{
    public interface ISeekerDTO : IUsersDTO<Seeker>
    {
        bool IsCreator { get; set; }
        CompanyDTO Company { get; set; }
        List<JobDTO> ListedJobs { get; set; }
    }
}
