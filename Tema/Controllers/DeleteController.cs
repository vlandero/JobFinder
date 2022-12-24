using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Tema.Services.Companies;
using Tema.Services.Finders;
using Tema.Services.Seekers;

namespace Tema.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DeleteController : ControllerBase
    {
        private readonly IFinderService _finderService;
        private readonly ISeekerService _seekerService;
        private readonly ICompanyService _companyService;

        public DeleteController(IFinderService finderService, ISeekerService seekerService, ICompanyService companyService)
        {
            _finderService = finderService;
            _seekerService = seekerService;
            _companyService = companyService;
        }

        [HttpDelete("delete-all-companies")]
        public IActionResult DeleteAllCompanies()
        {
            try
            {
                _companyService.DeleteAll();
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
    }
}
