using Tema.Models.DTOs.Applications;
using Tema.Models.DTOs.Jobs;
using Tema.Models.Jobs;
using Tema.Repositories.GenericRepository;

namespace Tema.Repositories.JobsRepository
{
    public interface IJobsRepository : IGenericRepository<Job>
    {
        List<JobDTO> GetAllOrdered();
        List<JobDTO> GetAllFromCompany(Guid id);
        List<JobDTO> GetAllFromSeeker(Guid id);
        List<ApplicationDTO> GetAllFromFinder(Guid id);
        Job GetByPostId(long id);
    }
}
