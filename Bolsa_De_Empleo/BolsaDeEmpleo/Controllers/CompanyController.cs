using DataAccess.Entities;
using DataAccess.Entities.DataToObject;
using Microsoft.AspNetCore.Mvc;
using Services.Service.IService;

namespace BolsaDeEmpleo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CompanyController : ControllerBase
    {
        private readonly ICompanyService _companyService;
        public CompanyController(ICompanyService companyService)
        {
            _companyService = companyService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Company>>> GetAll()
        {
            List<Company> companie = await _companyService.GetAll();
            return Ok(companie);
        }

        [HttpPost]
        public async Task<IActionResult> Create(CompanyVM comp_Request)
        {
            Company company = new Company();
            company.Name = comp_Request.Name;
            company.email = comp_Request.email;
            company.phoneNumber = comp_Request.phoneNumber;
            company.webSite = comp_Request.webSite;

            Company createdCompany = await _companyService.Create(company);
            return Ok(createdCompany);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            bool deleted = await _companyService.Delete(id);

            if (!deleted)
            {
                return NotFound();
            }

            return Ok();
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, CompanyVM comp_Request)
        {
            Company company = new Company();

            {
                company.Name = comp_Request.Name;
                company.email = comp_Request.email;
                company.phoneNumber = comp_Request.phoneNumber;
                company.webSite = comp_Request.webSite;
            }

            var updatedCompany = await _companyService.Update(id, company);

            if (updatedCompany == null)
            {
                return NotFound();
            }

            return Ok(updatedCompany);

        }

    }
}
