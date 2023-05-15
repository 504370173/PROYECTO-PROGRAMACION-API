﻿using DataAccess.Entities;
using Microsoft.AspNetCore.Mvc;
using Services.Service.IService;
using Microsoft.EntityFrameworkCore;
using DataAccess.Entities.RequestObjects;

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
        public async Task<ActionResult<IEnumerable<Candidate>>> GetAll()
        {

            List<Candidate> candidates = await _candidateService.GetAll();
            return Ok(candidates);
        }

        [HttpPost]
        public async Task<IActionResult> Create(CandidateVM can_Request)
        {
            Candidate candidate = new Candidate();
            candidate.name = can_Request.name;
            candidate.lastName1 = can_Request.lastName1;
            candidate.lastName2 = can_Request.lastName2;
            candidate.email = can_Request.email;
            candidate.phoneNumber = can_Request.phoneNumber;
            candidate.summary = can_Request.summary;
            candidate.createdAt = can_Request.createdAt;
            candidate.updatedAt = can_Request.updatedAt;
            candidate.status = can_Request.status;

            Candidate createdCandidate = await _candidateService.Create(candidate);
            return Ok(createdCandidate);

        }

    }
}