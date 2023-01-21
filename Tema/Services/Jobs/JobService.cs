using Tema.Models.DTOs.Applications;
using Tema.Models.DTOs.Response.Jobs;
using Tema.Models.Jobs;
using Tema.Repositories.GenericRepository;
using Tema.Repositories.JobsRepository;
using Tema.Services.Generic;

namespace Tema.Services.Jobs
{
    public class JobService : GenericService<Job>, IJobService
    {
        private readonly IJobsRepository _jobsRepository;
        public JobService(IGenericRepository<Job> repo, IJobsRepository jobsRepository) : base(repo)
        {
            _jobsRepository = jobsRepository;
        }
        public List<JobResponseDTO> GetAllOrdered()
        {
            return _jobsRepository.GetAllOrdered();
        }
        public List<JobResponseDTO> GetAllFromCompany(Guid id)
        {
            return _jobsRepository.GetAllFromCompany(id);
        }
        public List<JobResponseDTO> GetAllFromSeeker(Guid id)
        {
            return _jobsRepository.GetAllFromSeeker(id);
        }
        public List<ApplicationDTO> GetAllFromFinder(Guid id)
        {
            return _jobsRepository.GetAllFromFinder(id);
        }
        public Job GetByPostId(long id)
        {
            return _jobsRepository.GetByPostId(id);
        }
    }
}
