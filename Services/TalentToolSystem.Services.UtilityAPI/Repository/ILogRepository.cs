using TalentToolSystem.Services.UtilityAPI.Models;

namespace TalentToolSystem.Services.UtilityAPI.Repository
{
    public interface ILogRepository
    {
        Task<IEnumerable<CandidateLog>> GetAllCandidateLogs();
        Task<IEnumerable<DemandLog>> GetAllDemandLogs();
    }
}
