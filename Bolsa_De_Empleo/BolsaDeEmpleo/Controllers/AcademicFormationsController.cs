using DataAccess.Entities;
using DataAccess.Entities.RequestObjects;
using Microsoft.AspNetCore.Mvc;
using Services.Service.IService;
using DataAccess.ExtensionMethods;

namespace BolsaDeEmpleo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AcademicFormationsController : ControllerBase
    {
        private readonly IAcademicFormationService _academicFormationService;
        public AcademicFormationsController(IAcademicFormationService academicFormationService)
        {
            _academicFormationService = academicFormationService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<AcademicFormationVM>>> GetAll()
        {

            List<AcademicFormation> academicFormation = await _academicFormationService.GetAll();
            return Ok(academicFormation);
        }

        [HttpPost]
        public async Task<ActionResult<AcademicFormation>> PostAcademics(AcademicFormationVM acad_Request)
        {
            if(acad_Request == null)
            {
                return NotFound();
            }

            AcademicFormation createdAcademicFormation = await _academicFormationService.Create(acad_Request);
            return Ok(createdAcademicFormation);
        }


        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            bool deleted = await _academicFormationService.Delete(id);
            if (!deleted)
            {
                return NotFound();
            }

            return Ok();
        }


        [HttpPut("{id}")]
        public async Task<ActionResult<AcademicFormation>> Update(int id,  AcademicFormationVM acad_Request)
        {
            AcademicFormation academicFormation; //= new AcademicFormation();
            academicFormation = acad_Request.toAcademicFormation();

            var updatedCandidate = await _academicFormationService.Update(id, acad_Request);
            if (updatedCandidate == null)
            {
                return NotFound();
            }
            return Ok(updatedCandidate);

        }

    }
}
