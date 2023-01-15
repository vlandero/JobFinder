﻿using Microsoft.AspNetCore.Mvc;
using Tema.Helpers.Authorization;
using Tema.Models.DTOs.Applicants;
using Tema.Models.DTOs.Finders;
using Tema.Models.DTOs.Request.Users.Login;
using Tema.Models.DTOs.Request.Users.Register;
using Tema.Models.DTOs.Response.Users.Login;
using Tema.Models.Enums;
using Tema.Models.Jobs;
using Tema.Models.ManyToMany;
using Tema.Models.Users.Finder;
using Tema.Services.Finders;
using Tema.Services.Jobs;
using BCryptNet = BCrypt.Net.BCrypt;

namespace Tema.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FindersController : ControllerBase
    {
        private readonly IFinderService _finderService;
        private readonly IJobService _jobService;

        public FindersController(IJobService jobService, IFinderService finderService)
        {
            _finderService = finderService;
            _jobService = jobService;
        }

        [HttpPost("register-finder")]
        public async Task<IActionResult> RegisterFinder(FinderRequestRegisterDTO f)
        {
            var userToCreate = new Finder
            {
                Email = f.Email,
                FirstName = f.FirstName,
                LastName = f.LastName,
                PasswordHash = BCryptNet.HashPassword(f.Password),
                About = f.About,
                JobApplications = new List<Applicant>() { },
                Role = Role.User,
            };
            try
            {
                await _finderService.Create(userToCreate);
                return Ok();
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpPost("login-finder")]
        public async Task<IActionResult> LoginFinder(UserRequestLoginDTO f)
        {
            try
            {
                var finder = await _finderService.Login(f);
                return Ok(finder);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return BadRequest(e.Message);
            }
        }

        [Authorization(Role.Admin)]
        [HttpDelete("delete-all-finders")]
        public IActionResult DeleteAllFinders()
        {
            try
            {
                _finderService.DeleteAll();
                return Ok();
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
        
        [HttpDelete("delete-finder")]
        public async Task<IActionResult> DeleteFinder(string finderEmail)
        {
            try
            {
                Finder f = await _finderService.GetByEmail(finderEmail);
                _finderService.Delete(f);
                return Ok();
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
        [HttpPost("apply-to-job")]
        public async Task<IActionResult> ApplyToJob(ApplicantDTO a)
        {
            try
            {
                Finder f = await _finderService.GetByEmail(a.FinderEmail);
                Job j = await _jobService.GetByIdAsync(a.JobId);
                Applicant ap = new Applicant
                {
                    Finder = f,
                    Job = j,
                    FinderId = f.Id,
                    JobId = j.Id,
                    DateApplied = DateTime.Now
                };
                if (f.JobApplications == null)
                    f.JobApplications = new List<Applicant>();
                f.JobApplications.Add(ap);
                _finderService.Update(f);
                return Ok();
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
        [HttpPost("modify-finder")]
        public async Task<IActionResult> ModifyFinder(FinderResponseLoginDTO finder)
        {
            try
            {
                Finder f = await _finderService.GetByEmail(finder.Email);
                f.FirstName = finder.FirstName;
                f.LastName = finder.LastName;
                f.About = finder.About;
                f.Resume = finder.Resume;
                f.ProfilePicture = finder.ProfilePicture;
                _finderService.Update(f);
                return Ok();
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
        [HttpGet("get-finder/{name}")]
        public async Task<IActionResult> GetFinder(string name)
        {
            try
            {
                Finder f = await _finderService.GetByEmail(name);
                var jobsApplied = _jobService.GetAllFromFinder(f.Id);
                var dto = new FinderDTO(f, jobsApplied);
                return Ok(f);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

    }
}
