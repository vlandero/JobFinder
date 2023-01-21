using Tema.Models.DTOs.Companies;
using Tema.Models.DTOs.Response.Jobs;
using Tema.Models.DTOs.Users;
using Tema.Models.Users.Seeker;

namespace Tema.Models.DTOs.Seekers
{
    public interface ISeekerDTO : IUsersDTO<Seeker>
    {
        bool IsCreator { get; set; }
        CompanyResponseDTO Company { get; set; }
        List<JobResponseDTO> ListedJobs { get; set; }
    }
}
