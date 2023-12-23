using TalentToolSystem.Services.Search.DTO;

namespace TalentToolSystem.Services.Search.Services
{
    public interface ISearchService
    {
        public List<CandidateDTO?> SearchCandidates(CandidateRequestDTO requestDTO);
        public List<DemandDTO?> SearchDemands(DemandRequestDTO requestDTO);
    }
}
