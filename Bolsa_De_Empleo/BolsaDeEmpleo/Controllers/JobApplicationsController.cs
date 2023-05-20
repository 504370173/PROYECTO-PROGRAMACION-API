using DataAccess.Entities;
using DataAccess.Entities.DataToObject;
using Microsoft.AspNetCore.Mvc;
using Services.Service;
using Services.Service.IService;

namespace BolsaDeEmpleo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class JobApplicationsController : ControllerBase
    {
        private readonly IJobApplicationService _jobApplicationService;
        public JobApplicationsController(IJobApplicationService jobApplicationService)
        {
            _jobApplicationService = jobApplicationService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<JobApplicationVM>>> GetAll()
        {

            List<JobApplication> jobApplicationVM = await _jobApplicationService.GetAll();
            if (jobApplicationVM == null)
            {
                return NotFound();
            }
            return Ok(jobApplicationVM);
        }

        [HttpPost]
        public async Task<ActionResult<JobApplication>> PostJobApp(JobApplicationVM jobApp_Request)
        {
            if (jobApp_Request == null)
            {
                return BadRequest();
            }

            JobApplication newJobApp = await _jobApplicationService.Create(jobApp_Request);
            return Ok(jobApp_Request);

        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            bool deleted = await _jobApplicationService.Delete(id);
            if (!deleted)
            {
                return NotFound();
            }

            return Ok();
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, JobApplicationVM jobApp_Request)
        {
            if (jobApp_Request == null)
            {
                return BadRequest();
            }

            JobApplication updatedJobApplication = await _jobApplicationService.Update(id, jobApp_Request);
            if (updatedJobApplication == null)
            {
                return NotFound();
            }

            return Ok(updatedJobApplication);
        }


    }
}
