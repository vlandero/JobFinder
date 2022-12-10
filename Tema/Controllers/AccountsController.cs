using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Tema.Models.DTOs.Request.Users.Register;
using Tema.Models.Enums;
using Tema.Models.Users;
using Tema.Services.Finders;
using Tema.Services.Seekers;
using Tema.Services.Users;
using BCryptNet = BCrypt.Net.BCrypt;

namespace Tema.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountsController : ControllerBase
    {
        private IFinderService _finderService;
        private ISeekerService _seekerService;
        public AccountsController(IFinderService finderService, ISeekerService seekerService)
        {
            _finderService = finderService;
            _seekerService = seekerService;
        }
        [HttpGet("aa")]
        public int aa()
        {
            return 1;
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
                Role = Role.User
            };
            await _finderService.Create(userToCreate);
            return Ok();
        }
    }
}
