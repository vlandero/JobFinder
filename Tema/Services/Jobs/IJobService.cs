using Tema.Models.Jobs;
using Tema.Services.Generic;

namespace Tema.Services.Jobs
{
    public interface IJobService : IGenericService<Job>
    {
        List<Job> GetAllOrdered();
    }
}
