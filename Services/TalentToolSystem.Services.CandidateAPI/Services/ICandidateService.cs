using TalentToolSystem.Services.CandidateAPI.Model;

namespace TalentToolSystem.Services.CandidateAPI.Services
{
    public interface ICandidateService
    {
        public Task<int> CreateCandidate(Candidate candidate);
        public Task<List<Candidate>> GetAllCandidate();
        public Task<IEnumerable<Candidate>> GetCandidateById(int CandidateId);
        public Task<int> UpdateCandidate(Candidate candidate);
        public Task<bool> DeleteCandidate(int CandidateId);
    }
}
