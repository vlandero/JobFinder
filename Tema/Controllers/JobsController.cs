using Microsoft.AspNetCore.Mvc;
using Tema.Models.DTOs.Jobs;
using Tema.Models.Jobs;
using Tema.Models.ManyToMany;
using Tema.Models.Users.Finder;
using Tema.Models.Users.Seeker;
using Tema.Services.Jobs;
using Tema.Services.Seekers;

namespace Tema.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class JobsController : ControllerBase
    {
        private readonly IJobService _jobService;
        private readonly ISeekerService _seekerService;
        public JobsController(IJobService jobService, ISeekerService seekerService)
        {
            _jobService = jobService;
            _seekerService = seekerService;
        }

        [HttpGet("get-all-jobs")]
        public async Task<IActionResult> GetAll()
        {
            var jobs = _jobService.GetAllOrdered();
            return Ok(jobs);
        }

        //[Authorization(Role.Admin)]
        [HttpDelete("delete-all-jobs")]
        public IActionResult DeleteAllJobs()
        {
            try
            {
                _jobService.DeleteAll();
                return Ok();
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpPost("create-job")]
        public async Task<IActionResult> CreateJob(JobDTO j)
        {
            Seeker JobCreator = await _seekerService.GetByEmail(j.CreatorEmail);
            var jobToCreate = new Job
            {
                Name = j.Name,
                Description = j.Description,
                Salary = j.Salary,
                Applicants = new List<Applicant>(),
                Location = j.Location,
                Category = j.Category,
                Seeker = JobCreator,
                DateCreated = DateTime.Now
            };
            try
            {
                await _jobService.Create(jobToCreate);
                return Ok(j);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpPost("get-applicants")]
        public async Task<IActionResult> GetApplicants(long jobId)
        {
            try
            {
                Job j = _jobService.GetByPostId(jobId);
                List<Applicant> applicants = j.Applicants;
                List<Finder> applicantsFinders = new List<Finder>();
                foreach (Applicant a in applicants)
                {
                    applicantsFinders.Add(a.Finder);
                }
                return Ok(applicantsFinders);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
        
        [HttpGet("get-job/{id}")]
        public async Task<IActionResult> GetJobByPostId(long id)
        {
            try
            {
                Job j = _jobService.GetByPostId(id);
                var ret = new JobDTO(j);
                return Ok(ret);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

    }
}
