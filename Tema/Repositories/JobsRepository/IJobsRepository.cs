using Tema.Models.Jobs;
using Tema.Repositories.GenericRepository;

namespace Tema.Repositories.JobsRepository
{
    public interface IJobsRepository : IGenericRepository<Job>
    {
        List<Job> GetAllOrdered();
    }
}
