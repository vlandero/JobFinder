using Microsoft.AspNetCore.Mvc;
using Tema.Models.Companies;
using Tema.Models.DTOs.Request.Users.Login;
using Tema.Models.DTOs.Request.Users.Register;
using Tema.Models.Enums;
using Tema.Models.Jobs;
using Tema.Models.Users.Finder;
using Tema.Models.Users.Seeker;
using Tema.Services.Companies;
using Tema.Services.Finders;
using Tema.Services.Seekers;
using BCryptNet = BCrypt.Net.BCrypt;

namespace Tema.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountsController : ControllerBase
    {
        private readonly IFinderService _finderService;
        private readonly ISeekerService _seekerService;
        private readonly ICompanyService _companyService;
        
        public AccountsController(IFinderService finderService, ISeekerService seekerService, ICompanyService companyService)
        {
            _finderService = finderService;
            _seekerService = seekerService;
            _companyService = companyService;
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
                ListedJobs = new List<Job>(),
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
                    Employees = new List<Seeker>(),
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
    }
}
