using Tema.Models.DTOs.Applications;
using Tema.Models.DTOs.Response.Jobs;
using Tema.Models.Jobs;
using Tema.Repositories.GenericRepository;

namespace Tema.Repositories.JobsRepository
{
    public interface IJobsRepository : IGenericRepository<Job>
    {
        List<JobResponseDTO> GetAllOrdered();
        List<JobResponseDTO> GetAllFromCompany(Guid id);
        List<JobResponseDTO> GetAllFromSeeker(Guid id);
        List<ApplicationDTO> GetAllFromFinder(Guid id);
        Job GetByPostId(long id);
    }
}
