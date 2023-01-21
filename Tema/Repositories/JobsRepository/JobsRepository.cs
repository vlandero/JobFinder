using Tema.Models;
using Tema.Models.DTOs.Applications;
using Tema.Models.DTOs.Response.Jobs;
using Tema.Models.Jobs;
using Tema.Repositories.GenericRepository;

namespace Tema.Repositories.JobsRepository
{
    public class JobsRepository : GenericRepository<Job>, IJobsRepository
    {
        public JobsRepository(MyAppContext context) : base(context)
        {

        }

        public List<JobResponseDTO> GetAllOrdered()
        {
            var x = from job in _table
                   orderby job.DateCreated descending
                   select new JobResponseDTO(job);
            
            return x.ToList();
        }
        public List<JobResponseDTO> GetAllFromCompany(Guid id)
        {
            var x = from job in _context.Jobs
                    join s in _context.Seekers on job.Seeker.Id equals s.Id
                    join c in _context.Companies on s.Company.Id equals c.Id
                    where c.Id == id
                    select new JobResponseDTO(job);
            return x.ToList();
        }
        public List<ApplicationDTO> GetAllFromFinder(Guid id)
        {
            var x = from job in _context.Jobs
                    join a in _context.Applicants on job.Id equals a.Job.Id
                    join f in _context.Finders on a.Finder.Id equals f.Id
                    join s in _context.Seekers on job.Seeker.Id equals s.Id
                    join c in _context.Companies on s.Company.Id equals c.Id
                    where f.Id == id
                    select new ApplicationDTO(c, job);
            return x.ToList();
        }
        public List<JobResponseDTO> GetAllFromSeeker(Guid id)
        {
            var x = from job in _context.Jobs
                    join s in _context.Seekers on job.Seeker.Id equals s.Id
                    where s.Id == id
                    select new JobResponseDTO(job);
            return x.ToList();
            
        }
        public Job GetByPostId(long id)
        {
            var x = from job in _table
                    where job.PostId == id
                    select job;
            return x.FirstOrDefault();
        }
    }
}
