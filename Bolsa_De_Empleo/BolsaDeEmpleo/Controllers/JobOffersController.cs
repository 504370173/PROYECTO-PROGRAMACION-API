using DataAccess.Entities;
using DataAccess.Entities.DataToObject;
using Microsoft.AspNetCore.Mvc;
using Services.Service;
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
        public async Task<ActionResult<IEnumerable<JobOffer>>> GetAll()
        {

            List<JobOffer> jobOffer = await _jobOfferService.GetAll();
            return Ok(jobOffer);
        }

        [HttpPost]
        public async Task<IActionResult> Create(JobOfferVM offer_Request)
        {
            JobOffer jobOffer = new JobOffer();
            jobOffer.position = offer_Request.position;
            jobOffer.description = offer_Request.description;
            jobOffer.createdAt = offer_Request.createdAt;
            jobOffer.updatedAt = offer_Request.updatedAt;
            jobOffer.status = offer_Request.status;
            jobOffer.companyId = offer_Request.companyId;

            JobOffer createdJobOffer = await _jobOfferService.Create(jobOffer);
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
        public async Task<IActionResult> Update(int id, JobOfferVM offer_)
        {
            JobOffer jobOffer = new JobOffer();
            {
                jobOffer.position = offer_.position;
                jobOffer.description = offer_.description;
                jobOffer.createdAt = offer_.createdAt;
                jobOffer.updatedAt= offer_.updatedAt;
                jobOffer.status = offer_.status;
            }

            var updatedOffer = await _jobOfferService.Update(id, jobOffer);
            if (updatedOffer == null)
            {
                return NotFound();
            }
            return Ok(updatedOffer);

        }

    }
}
