using Microsoft.AspNetCore.Mvc;
using TalentToolSystem.Services.Search.DTO;
using TalentToolSystem.Services.Search.Services;

namespace TalentToolSystem.Services.Search.Controllers
{
    [Route("api/search")]
    [ApiController]
    public class SearchController : ControllerBase
    {
        private readonly ISearchService _searchService;
        public SearchController(ISearchService searchService)
        {
            _searchService = searchService;
        }

        [HttpGet("SearchCandidates")]
        public async Task<IActionResult> Get([FromQuery] CandidateRequestDTO requestDTO)
        {
            try
            {
                List<CandidateDTO?> results = _searchService.SearchCandidates(requestDTO);
                return Ok(results);
            }
            catch (Exception)
            {
                return StatusCode(500, "An error occurred while processing your request.");
            }
        }

        [HttpGet("SearchDemands")]
        public async Task<IActionResult> Get([FromQuery] DemandRequestDTO requestDTO)
        {
            try
            {
                List<DemandDTO?> results = _searchService.SearchDemands(requestDTO);
                return Ok(results);
            }
            catch (Exception)
            {
                return StatusCode(500, "An error occurred while processing your request.");
            }
        }

    }

}
