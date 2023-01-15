using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Tema.Models.Companies;
using Tema.Models.DTOs.Companies;
using Tema.Services.Companies;

namespace Tema.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CompaniesController : ControllerBase
    {
        private readonly ICompanyService _companyService;
        public CompaniesController(ICompanyService companyService)
        {
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
        [HttpDelete("delete-company/{name}")]
        public async Task<IActionResult> DeleteCompany(string name)
        {
            try
            {
                Company c = await _companyService.GetByName(name);
                _companyService.Delete(c);
                return Ok();
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
        [HttpPost("modify-company")]
        public async Task<IActionResult> ModifyCompany(CompanyDTO c)
        {
            try
            {
                Company company = await _companyService.GetByName(c.Name);
                company.Name = c.Name;
                company.Description = c.Description!;
                company.Location = c.Location!;
                company.Logo = c.Logo;
                _companyService.Update(company);
                return Ok();
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
    }
}
