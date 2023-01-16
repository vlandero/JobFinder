using Tema.Models.DTOs.Applications;
using Tema.Models.DTOs.Jobs;
using Tema.Models.Jobs;
using Tema.Services.Generic;

namespace Tema.Services.Jobs
{
    public interface IJobService : IGenericService<Job>
    {
        List<JobDTO> GetAllOrdered();

        List<JobDTO> GetAllFromCompany(Guid id);
        List<JobDTO> GetAllFromSeeker(Guid id);
        List<ApplicationDTO> GetAllFromFinder(Guid id);
        Job GetByPostId(long id);
    }
}
