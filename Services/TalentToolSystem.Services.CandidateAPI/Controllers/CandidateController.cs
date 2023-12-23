using Microsoft.AspNetCore.Mvc;
using TalentToolSystem.Services.CandidateAPI.Model;
using TalentToolSystem.Services.CandidateAPI.Services;
using TalentToolSystem.Services.UtilityAPI.Logger;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace TalentToolSystem.Services.CandidateAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CandidateController : ControllerBase
    {
        private readonly ICandidateService candidateService;

        public CandidateController(ICandidateService candidateService)
        {

            this.candidateService = candidateService;

        }

        // GET: api/<CandidateController>
        [HttpGet("getcandidatelist")]
        public async Task<List<Candidate>> Get()
        {
            try
            {
                return await candidateService.GetAllCandidate();
            }
            catch
            {
                throw;
            }
        }

        // GET api/<CandidateController>/5
        [HttpGet("getcandidatebyid")]
        public async Task<IEnumerable<Candidate>?> Get(int CandidateId)
        {
            try
            {
                var response = await candidateService.GetCandidateById(CandidateId);

                if (response == null)
                {
                    return null;
                }
                return response;
            }
            catch
            {
                throw;
            }
        }

        // POST api/<CandidateController>
        [HttpPost("addcandidate")]
        public async Task<IActionResult> Post(Candidate candidate)
        {
            if (candidate == null)
            {
                return BadRequest();
            }
            try
            {
                var result = await candidateService.CreateCandidate(candidate);
                if (result == 0)
                {
                    return BadRequest();
                }
                return Ok(result);
            }
            catch
            {
                throw;
            }
        }

        // PUT api/<CandidateController>/5
        [HttpPut("updatecandidate")]
        public async Task<IActionResult> Put(Candidate candidate)
        {
            if (candidate == null)
            {
                return BadRequest();
            }

            try
            {
                var result = await candidateService.UpdateCandidate(candidate);
                return Ok(result);
            }
            catch
            {
                throw;
            }
        }

        // DELETE api/<CandidateController>/5
        [HttpDelete("deletecandidate")]
        public async Task<bool> Delete(int CandidateId)
        {  
            try
            {
                IEnumerable<Candidate> candidates = await candidateService.GetCandidateById(CandidateId);
                Candidate candidate = candidates.FirstOrDefault();
                bool response = await candidateService.DeleteCandidate(CandidateId);
                if (response)
                {
                    CustomLogger.Information(candidate);
                }
                return response;
            }
            catch
            {
                throw;
            }
        }
    }
}