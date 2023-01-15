﻿using Microsoft.AspNetCore.Mvc;
using Tema.Helpers.Authorization;
using Tema.Models.Companies;
using Tema.Models.DTOs.Applicants;
using Tema.Models.DTOs.Request.Users.Login;
using Tema.Models.DTOs.Request.Users.Register;
using Tema.Models.DTOs.Response.Users.Login;
using Tema.Models.DTOs.TransferOwnership;
using Tema.Models.Enums;
using Tema.Models.Jobs;
using Tema.Models.ManyToMany;
using Tema.Models.Users.Finder;
using Tema.Models.Users.Seeker;
using Tema.Services.Companies;
using Tema.Services.Finders;
using Tema.Services.Jobs;
using Tema.Services.Seekers;
using BCryptNet = BCrypt.Net.BCrypt;

namespace Tema.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SeekersController : ControllerBase
    {
        private readonly ISeekerService _seekerService;
        private readonly ICompanyService _companyService;

        public SeekersController(ISeekerService seekerService, ICompanyService companyService)
        {
            _seekerService = seekerService;
            _companyService = companyService;
        }


        [HttpPost("register-seeker")]
        public async Task<IActionResult> RegisterSeeker(SeekerRequestRegisterDTO s)
        {
            var userToCreate = new Seeker
            {
                Email = s.Email,
                FirstName = s.FirstName,
                LastName = s.LastName,
                PasswordHash = BCryptNet.HashPassword(s.Password),
                Role = Role.User,
                ListedJobs = new List<Job>() { },
                IsCreator = s.Created
            };
            if (s.Created == true)
            {
                var newCompany = new Company
                {
                    Name = s.CompanyDTO.Name,
                    Description = s.CompanyDTO.Description!,
                    Location = s.CompanyDTO.Location!,
                    Logo = s.CompanyDTO.Logo,
                    Employees = new List<Seeker>() { },
                };
                userToCreate.Company = newCompany;
                try
                {
                    await _seekerService.Create(userToCreate);
                    Seeker seeker = await _seekerService.GetByEmail(s.Email);
                    Company companyFromDB = seeker.Company;
                    companyFromDB.CreatorId = seeker.Id;
                    _companyService.Update(companyFromDB);
                }
                catch (Exception e)
                {
                    return BadRequest(e.Message);
                }
            }
            else
            {
                try
                {
                    userToCreate.Company = await _companyService.GetByName(s.CompanyDTO.Name);
                    await _seekerService.Create(userToCreate);
                }
                catch (Exception e)
                {
                    return BadRequest(e.Message);
                }
            }
            return Ok();
        }
        [HttpPost("login-seeker")]
        public async Task<IActionResult> LoginSeeker(UserRequestLoginDTO s)
        {
            try
            {
                var seeker = await _seekerService.Login(s);
                return Ok(seeker);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
        
        [Authorization(Role.Admin)]
        [HttpDelete("delete-all-seekers")]
        public IActionResult DeleteAllSeekers()
        {
            try
            {
                _seekerService.DeleteAll();
                return Ok();
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
        [HttpDelete("delete-seeker")]
        public async Task<IActionResult> DeleteSeeker(string seekerEmail)
        {
            try
            {
                Seeker s = await _seekerService.GetByEmail(seekerEmail);
                if (!s.IsCreator)
                {
                    _seekerService.Delete(s);
                    return Ok();
                }
                else
                {
                    return BadRequest("You can't delete the creator of a job! Transfer the ownership before deleting!");
                }
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
        
        [HttpPost("modify-seeker")]
        public async Task<IActionResult> ModifySeeker(SeekerResponseLoginDTO seeker)
        {
            try
            {
                Seeker s = await _seekerService.GetByEmail(seeker.Email);
                s.FirstName = seeker.FirstName;
                s.LastName = seeker.LastName;
                s.ProfilePicture = seeker.ProfilePicture;
                _seekerService.Update(s);
                return Ok();
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
        [HttpPost("transfer-ownership")]
        public async Task<IActionResult> TransferOwnership(TransferOwnershipDTO to)
        {
            try
            {
                Seeker currentOwner = await _seekerService.GetByEmail(to.CurrentOwnerEmail);
                Seeker newOwner = await _seekerService.GetByEmail(to.NewOwnerEmail);
                if (currentOwner.Company.Id != newOwner.Company.Id)
                {
                    return BadRequest("User are on different companies");
                }
                Company c = await _companyService.GetByIdAsync(currentOwner.Company.Id);
                c.CreatorId = newOwner.Id;
                newOwner.IsCreator = true;
                currentOwner.IsCreator = false;
                _companyService.Update(c);
                _seekerService.Update(currentOwner);
                _seekerService.Update(newOwner);

                return Ok();
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
    }
}