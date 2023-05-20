using DataAccess.Entities;
using Microsoft.AspNetCore.Mvc;
using Services.Service.IService;
using DataAccess.Entities.RequestObjects;
using DataAcces;

namespace BolsaDeEmpleo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CandidatesController : ControllerBase
    {
       private readonly ICandidateService _candidateService;
       public CandidatesController(ICandidateService candidateService)
        {
            _candidateService = candidateService;
        }

        //GET: api/Candidates
        [HttpGet]
        public async Task<ActionResult<IEnumerable<CandidateVM>>> GetAll()
        {

            List<Candidate> candidates = await _candidateService.GetAll();
            return Ok(candidates);
        }

        [HttpPost]
        public async Task<IActionResult> Create(CandidateVM can_Request)
        {
            if( can_Request == null) 
            {
                return BadRequest();
            }

            Candidate c = await _candidateService.Create(can_Request);

            //Candidate createdCandidate = await
            //_candidateService.Create(candidate);
            return Ok(c);

        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            bool deleted = await _candidateService.Delete(id);
            if (!deleted)
            {
                return NotFound();
            }

            return Ok();
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, CandidateVM can_Request)
        {
            Candidate candidate = new Candidate();
            candidate = can_Request.toCandidate();

            var updatedCandidate = await _candidateService.Update(id, can_Request);
            if (updatedCandidate == null)
            {
                return NotFound();
            }
            return Ok(updatedCandidate);
        }

    }
}



//[HttpPut("{id}")]
//public async Task<IActionResult> Update(int id, CandidateVM can_Request)
//{
//    if (can_Request == null)
//    {
//        return BadRequest();
//    }

//    var k = await _candidateService.GetById(id);

//    if (k == null)
//    {
//        return NotFound();
//    }

//    await _candidateService.Update(id, can_Request);
//    return NoContent();

//    //Candidate updatedCandidate = await _candidateService.Update(id, can_Request);
//    //if (updatedCandidate == null)
//    //{
//    //    return NotFound();
//    //}

//    //return Ok(updatedCandidate);
//}
