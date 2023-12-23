using Microsoft.AspNetCore.Mvc;
using TalentToolSystem.Services.UtilityAPI.Models;
using TalentToolSystem.Services.UtilityAPI.Repository;

namespace TalentToolSystem.Services.UtilityAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LogsController : ControllerBase
    {
        readonly ILogRepository _logRepository;
        public LogsController(ILogRepository logRepository)
        {
            this._logRepository = logRepository;
        }

        [HttpGet("GetAllCandidateLogs")]
        public async Task<object> GetCandidate()
        {
            IEnumerable<CandidateLog> logs;
            try
            {
                logs = await _logRepository.GetAllCandidateLogs();
                return logs;
            }
            catch (Exception ex)
            {
                return new List<string>() { ex.ToString() };
            }
        }

        [HttpGet("GetAllDemandLogs")]
        public async Task<object> GetDemand()
        {
            IEnumerable<DemandLog> logs;
            try
            {
                logs = await _logRepository.GetAllDemandLogs();
                return logs;
            }
            catch (Exception ex)
            {
                return new List<string>() { ex.ToString() };
            }
        }
    }
}
