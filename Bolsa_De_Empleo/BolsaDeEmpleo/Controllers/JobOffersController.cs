using DataAccess.Entities;
using DataAccess.Entities.DataToObject;
using DataAccess.ExtensionMethods;
using Microsoft.AspNetCore.Mvc;
using Services.Service.IService;

namespace BolsaDeEmpleo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class JobOffersController : ControllerBase
    {
        private readonly IJobOfferService _jobOfferService;
        public JobOffersController(IJobOfferService jobOffersService)
        {
            _jobOfferService = jobOffersService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<JobOfferVM>>> GetAll()
        {

            List<JobOffer> jobOffer = await _jobOfferService.GetAll();
            return Ok(jobOffer);
        }

        [HttpPost]
        public async Task<ActionResult<JobOffer>> Create(JobOfferVM offer_Request)
        {
            if (offer_Request == null)
            {
                return NotFound();
            }

            JobOffer createdJobOffer = await _jobOfferService.Create(offer_Request);
            return Ok(createdJobOffer);

        }


        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            bool deleted = await _jobOfferService.Delete(id);
            if (!deleted)
            {
                return NotFound();
            }

            return Ok();
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<JobOffer>> Update(int id, JobOfferVM offer_)
        {
            JobOffer jobOffer; //= new JobOffer();
            jobOffer = offer_.toJobOffer();
           

            var updatedOffer = await _jobOfferService.Update(id, offer_);

            if (updatedOffer == null)
            {
                return NotFound();
            }

            return Ok(updatedOffer);

        }

    }
}
