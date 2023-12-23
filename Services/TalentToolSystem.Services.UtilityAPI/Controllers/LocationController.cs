using Azure;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TalentToolSystem.Services.UtilityAPI.Data;
using TalentToolSystem.Services.UtilityAPI.Logger;
using TalentToolSystem.Services.UtilityAPI.Models;
using TalentToolSystem.Services.UtilityAPI.Repository;

namespace TalentToolSystem.Services.UtilityAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LocationController : ControllerBase
    {
        private ILocationRepository _locationRepository;
        private readonly ILogger<LocationController> _logger;
        public LocationController(ILocationRepository locationRepository, ILogger<LocationController> logger)
        {
            _locationRepository = locationRepository;
            _logger = logger;
        }

        [HttpGet("GetAllLocations")]
        public async Task<object> Get()
        {
            IEnumerable<Location> locations;
            try
            {
                locations = await _locationRepository.GetAllLocations();
                return locations;
            }
            catch (Exception ex)
            {
                return new List<string>() { ex.ToString() };
            }
        }

        // POST api/<LocationController>
        //[HttpPost("CreateLocation")]
        //public async Task<object> Post([FromBody] Location location)
        //{
        //    try
        //    {
        //        Location model = await _locationRepository.CreateUpdateLocation(location);
        //        return location;
        //    }
        //    catch (Exception ex)
        //    {
        //        return new List<string>() { ex.ToString() };
        //    }

        //}

        // PUT api/<LocationController>/5
        //[HttpPut("UpdateLocation/{id}")]
        //public async Task<object> Put([FromBody] Location location)
        //{
        //    try
        //    {
        //        Location model = await _locationRepository.CreateUpdateLocation(location);
        //        return model;
        //    }
        //    catch (Exception ex)
        //    {
        //        return new List<string>() { ex.ToString() };
        //    }
        //}

        //[HttpDelete("DeleteLocation/{id}")]
        //public async Task<object> Delete(int id)
        //{
        //    try
        //    {
        //        Location location = await _locationRepository.GetLocationById(id);
        //        bool IsDeleted = await _locationRepository.DeleteLocation(id);
        //        if (IsDeleted)
        //        {
        //            CustomLogger.Information(location);
        //        }
        //        return IsDeleted;
        //    }
        //    catch (Exception ex)
        //    {
        //        return new List<string>() { ex.ToString() };
        //    }
        //}
    }
}
