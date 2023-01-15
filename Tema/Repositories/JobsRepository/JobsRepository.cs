using Tema.Models;
using Tema.Models.Jobs;
using Tema.Repositories.GenericRepository;

namespace Tema.Repositories.JobsRepository
{
    public class JobsRepository : GenericRepository<Job>, IJobsRepository
    {
        public JobsRepository(MyAppContext context) : base(context)
        {

        }

        public List<Job> GetAllOrdered()
        {
            var x = from job in _table
                   orderby job.DateCreated descending
                   select job;
            
            return x.ToList();
        }
    }
}
