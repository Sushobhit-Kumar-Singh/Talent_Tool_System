using Microsoft.EntityFrameworkCore;
using TalentToolSystem.Services.UtilityAPI.Data;
using TalentToolSystem.Services.UtilityAPI.Logger;
using TalentToolSystem.Services.UtilityAPI.Models;

namespace TalentToolSystem.Services.UtilityAPI.Repository
{
    public class LocationRepository : ILocationRepository
    {
        private readonly UtilityDbContext _context;
        public LocationRepository(UtilityDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Location>> GetAllLocations()
        {
            List<Location> locations = await _context.Locations.ToListAsync();
            return locations;
        }

        public async Task<Location> CreateUpdateLocation(Location location)
        {
            if (location.LocationId > 0)
            {
                _context.Locations.Update(location);
            }
            else
            {
                _context.Add(location);
            }
            await _context.SaveChangesAsync();
            return location;
        }

        public async Task<bool> DeleteLocation(int id)
        {
            try
            {
                Location location = await _context.Locations.FirstOrDefaultAsync(x => x.LocationId == id);
                if (location == null)
                {
                    return false;
                }
                _context.Locations.Remove(location);
                await _context.SaveChangesAsync();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public async Task<Location> GetLocationById(int id)
        {
            Location location = await _context.Locations.FirstOrDefaultAsync(x => x.LocationId == id);
            return location;

        }
    }
}
