using TalentToolSystem.Services.DemandAPI.Model;

namespace TalentToolSystem.Services.DemandAPI.Service
{
    public interface IDemandService
    {
        public Task<int> CreateDemand(Demand demand);
        public Task<List<Demand>> GetAllDemand();
        public Task<IEnumerable<Demand>> GetDemandById(int DemandId);
        public Task<int> UpdateDemand(Demand demand);
        public Task<bool> DeleteDemand(int DemandId);
    }
}
