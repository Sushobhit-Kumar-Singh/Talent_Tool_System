using TalentToolSystem.Services.UtilityAPI.Models;

namespace TalentToolSystem.Services.UtilityAPI.Repository
{
    public interface ILocationRepository
    {
        Task<IEnumerable<Location>> GetAllLocations();
        Task<Location> CreateUpdateLocation(Location location);
        Task<bool> DeleteLocation(int id);
        Task<Location> GetLocationById(int id);
    }
}
