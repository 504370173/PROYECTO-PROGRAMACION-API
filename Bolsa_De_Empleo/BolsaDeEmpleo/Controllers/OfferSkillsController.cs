using DataAccess.Entities;
using DataAccess.Entities.DataToObject;
using Microsoft.AspNetCore.Mvc;
using Services.Service;
using Services.Service.IService;

namespace BolsaDeEmpleo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OfferSkillsController : ControllerBase
    {
        private readonly IOfferSkillService _offerSkillService;
        public OfferSkillsController(IOfferSkillService offerSkillService)
        {
            _offerSkillService = offerSkillService;
        }

        //GET: api/CandidatesSkill
        [HttpGet]
        public async Task<ActionResult<IEnumerable<OfferSkillVM>>> GetAll()
        {
            List<OfferSkill> offerSkillVM = await _offerSkillService.GetAll();
            if (offerSkillVM == null)
            {
                return NotFound();
            }
            return Ok(offerSkillVM);
        }


        [HttpPost]
        public async Task<ActionResult<OfferSkill>> PostOfferSkills(OfferSkillVM offerSkill_Request)
        {
            if (offerSkill_Request == null)
            {
                return BadRequest();
            }

            OfferSkill newOfferSkill = await _offerSkillService.Create(offerSkill_Request);
            return Ok(newOfferSkill);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            bool deleted = await _offerSkillService.Delete(id);
            if (!deleted)
            {
                return NotFound();
            }

            return Ok();
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, OfferSkillVM offerSkill_Request)
        {
            if (offerSkill_Request == null)
            {
                return BadRequest();
            }

            OfferSkill updatedOfferSkill = await _offerSkillService.Update(id, offerSkill_Request);
            if (updatedOfferSkill == null)
            {
                return NotFound();
            }

            return Ok(updatedOfferSkill);
        }

    }
    
}

