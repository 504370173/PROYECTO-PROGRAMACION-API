using DataAccess.Entities;
using DataAccess.Entities.DataToObject;
using Microsoft.AspNetCore.Mvc;
using Services.Service;
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
        public async Task<ActionResult<IEnumerable<CompanyVM>>> GetAll()
        {
            List<Company> companie = await _companyService.GetAll();
            return Ok(companie);
        }

        [HttpPost]
        public async Task<IActionResult> PostCompany(CompanyVM comp_Request)
        {
            if (comp_Request == null)
            {
                return BadRequest();
            }

            Company c = await _companyService.Create(comp_Request);

            //Candidate createdCandidate = await
            //_candidateService.Create(candidate);
            return Ok(c);
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
            if (comp_Request == null)
            {
                return BadRequest();
            }

            var updatedCompany = await _companyService.Update(id, comp_Request);

            if (updatedCompany == null)
            {
                return NotFound();
            }

            return Ok(updatedCompany);

        }

    }
}
