using DataAccess.Entities;
using DataAccess.Entities.RequestObjects;
using Microsoft.AspNetCore.Mvc;
using Services.Service;
using Services.Service.IService;

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
        public async Task<ActionResult<IEnumerable<AcademicFormation>>> GetAll()
        {

            List<AcademicFormation> academicFormation = await _academicFormationService.GetAll();
            return Ok(academicFormation);
        }

        [HttpPost]
        public async Task<IActionResult> Create(AcademicFormationVM acad_Request)
        {
            AcademicFormation academicFormation = new AcademicFormation();
            academicFormation.institution = acad_Request.institution;
            academicFormation.degree = acad_Request.degree;
            academicFormation.startDate = acad_Request.startDate;
            academicFormation.endDate = acad_Request.endDate;
            academicFormation.candidateId = acad_Request.candidateId;


            AcademicFormation createdAcademicFormation = await _academicFormationService.Create(academicFormation);
            return Ok(createdAcademicFormation);

        }


    }
}
