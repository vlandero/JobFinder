using Tema.Models.Jobs;
using Tema.Repositories.GenericRepository;
using Tema.Repositories.JobsRepository;
using Tema.Services.Generic;

namespace Tema.Services.Jobs
{
    public class JobService : GenericService<Job>, IJobService
    {
        private readonly IJobsRepository _jobsRepository;
        public JobService(IGenericRepository<Job> repo ,IJobsRepository jobsRepository) : base(repo)
        {
            _jobsRepository = jobsRepository;
        }
        public List<Job> GetAllOrdered()
        {
            return _jobsRepository.GetAllOrdered();
        }
    }
}
