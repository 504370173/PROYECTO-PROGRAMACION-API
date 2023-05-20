using DataAccess.Entities;
using DataAccess.Entities.DataToObject;
using Microsoft.AspNetCore.Mvc;
using Services.Service.IService;

namespace BolsaDeEmpleo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CandidateSkillsController : Controller
    {
        private readonly ICandidateSkillService _candidateSkillService;
        public CandidateSkillsController(ICandidateSkillService candidateSkillService)
        {
            _candidateSkillService = candidateSkillService;
        }

        //GET: api/CandidatesSkill
        [HttpGet]
        public async Task<ActionResult<IEnumerable<CandidateSkillVM>>> GetAll()
        {

            List<CandidateSkill> candidateSkillVm = await _candidateSkillService.GetAll();
            if(candidateSkillVm == null)
            {
                return NotFound();
            }
            return Ok(candidateSkillVm);
        }

        [HttpPost]
        public async Task<ActionResult<CandidateSkill>> PostCanSkills(CandidateSkillVM canSkill_Request)
        {
            if(canSkill_Request == null)
            {
                return BadRequest();
            }

            CandidateSkill newCandidateSkill = await _candidateSkillService.Create(canSkill_Request);
            return Ok(newCandidateSkill);

        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            bool deleted = await _candidateSkillService.Delete(id);
            if (!deleted)
            {
                return NotFound();
            }

            return Ok();
        }


        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, CandidateSkillVM canSkill_Request)
        {
            if (canSkill_Request == null)
            {
                return BadRequest();
            }

            CandidateSkill updatedCandidateSkill = await _candidateSkillService.Update(id, canSkill_Request);
            if (updatedCandidateSkill == null)
            {
                return NotFound();
            }

            return Ok(updatedCandidateSkill);
        }

    }
}
