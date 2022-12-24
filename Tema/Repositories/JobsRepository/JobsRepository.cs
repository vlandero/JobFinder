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
    }
}
