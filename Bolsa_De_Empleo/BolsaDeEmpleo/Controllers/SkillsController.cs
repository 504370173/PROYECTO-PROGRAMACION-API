using DataAccess.Entities;
using DataAccess.Entities.DataToObject;
using Microsoft.AspNetCore.Mvc;
using Services.Service.IService;
using DataAccess.ExtensionMethods;


namespace BolsaDeEmpleo.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class SkillsController : ControllerBase
    {
        private readonly ISkillService _skillService;
        public SkillsController(ISkillService skillService)
        {
            _skillService = skillService;
        }

        //GET: api/Candidates
        [HttpGet]
        public async Task<ActionResult<IEnumerable<SkillVM>>> GetAll()
        {

            List<Skill> skill = await _skillService.GetAll();
            return Ok(skill);
        }

        [HttpPost]
        public async Task<ActionResult<Skill>> Create(SkillVM skill_Request)
        {
            if (skill_Request == null)
            {
                return NotFound();
            }

            Skill skill = await _skillService.Create(skill_Request);
            return Ok(skill);

        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            bool deleted = await _skillService.Delete(id);
            if (!deleted)
            {
                return NotFound();
            }

            return Ok();
        }


        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, SkillVM skill_Request)
        {
            Skill skill; //= new AcademicFormation();
            skill = skill_Request.toSkill();

            var updatedSkill = await _skillService.Update(id, skill_Request);
            if (updatedSkill == null)
            {
                return NotFound();
            }
            return Ok(updatedSkill);
        }


    }
}
