﻿using Tema.Models.DTOs.Applications;
using Tema.Models.DTOs.Response.Jobs;
using Tema.Models.Jobs;
using Tema.Services.Generic;

namespace Tema.Services.Jobs
{
    public interface IJobService : IGenericService<Job>
    {
        List<JobResponseDTO> GetAllOrdered();

        List<JobResponseDTO> GetAllFromCompany(Guid id);
        List<JobResponseDTO> GetAllFromSeeker(Guid id);
        List<ApplicationDTO> GetAllFromFinder(Guid id);
        Job GetByPostId(long id);
    }
}
