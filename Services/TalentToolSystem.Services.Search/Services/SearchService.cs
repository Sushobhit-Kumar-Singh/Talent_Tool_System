using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using TalentToolSystem.Services.Search.DTO;

namespace TalentToolSystem.Services.Search.Services
{
    public class SearchService : ISearchService
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public SearchService(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public List<CandidateDTO?> SearchCandidates(CandidateRequestDTO requestDTO)
        {
            try
            {
                var filteredCandidates = GetCandidates();

                if (!string.IsNullOrEmpty(requestDTO.Account))
                {
                    filteredCandidates = filteredCandidates.Where(c =>
                    c.Account.ToLower().Contains(requestDTO.Account.ToLower()) || c.Account.ToLower() == requestDTO.Account.ToLower()).ToList();
                }

                if (!string.IsNullOrEmpty(requestDTO.CandidateName))
                {
                    filteredCandidates = filteredCandidates.Where(c => c.CandidateName.ToLower() == requestDTO.CandidateName.ToLower() || c.CandidateName.ToLower().Contains(requestDTO.CandidateName.ToLower())).ToList();
                }

                if (!string.IsNullOrEmpty(requestDTO.Manager))
                {
                    filteredCandidates = filteredCandidates.Where(c => c.Manager.ToLower() == requestDTO.Manager.ToLower() || c.Manager.ToLower().Contains(requestDTO.Manager.ToLower())).ToList();
                }

                if (!string.IsNullOrEmpty(requestDTO.Status))
                {
                    filteredCandidates = filteredCandidates.Where(c => c.Status.ToLower() == requestDTO.Status.ToLower() || c.Status.ToLower().Contains(requestDTO.Status.ToLower())).ToList();
                }

                if (!string.IsNullOrEmpty(requestDTO.Location))
                {
                    filteredCandidates = filteredCandidates.Where(c => c.Location.ToLower() == requestDTO.Location.ToLower() || c.Location.ToLower().Contains(requestDTO.Location.ToLower())).ToList();
                }

                if (requestDTO.ReferralId.HasValue)
                {
                    filteredCandidates = filteredCandidates.Where(c => c.ReferralId == requestDTO.ReferralId).ToList();
                }

                return filteredCandidates;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error in SearchCandidates: {ex.Message}");
                throw;
            }
        }

        public List<DemandDTO?> SearchDemands(DemandRequestDTO requestDTO)
        {
            try
            {
                var filteredDemands = GetDemands();

                if (!string.IsNullOrEmpty(requestDTO.Account))
                {
                    filteredDemands = filteredDemands.Where(c =>
                    c.AccountName.ToLower().Contains(requestDTO.Account.ToLower()) || c.AccountName.ToLower() == requestDTO.Account.ToLower()).ToList();
                }

                if (!string.IsNullOrEmpty(requestDTO.Demand))
                {
                    filteredDemands = filteredDemands.Where(c => c.DemandName.ToLower() == requestDTO.Demand.ToLower() || c.DemandName.ToLower().Contains(requestDTO.Demand.ToLower())).ToList();
                }

                if (!string.IsNullOrEmpty(requestDTO.Manager))
                {
                    filteredDemands = filteredDemands.Where(c => c.Manager.ToLower() == requestDTO.Manager.ToLower() || c.Manager.ToLower().Contains(requestDTO.Manager.ToLower())).ToList();
                }

                if (!string.IsNullOrEmpty(requestDTO.Status))
                {
                    filteredDemands = filteredDemands.Where(c => c.Status.ToLower() == requestDTO.Status.ToLower() || c.Status.ToLower().Contains(requestDTO.Status.ToLower())).ToList();
                }

                if (!string.IsNullOrEmpty(requestDTO.Location))
                {
                    filteredDemands = filteredDemands.Where(c => c.Location.ToLower() == requestDTO.Location.ToLower() || c.Location.ToLower().Contains(requestDTO.Location.ToLower())).ToList();
                }

                if (!string.IsNullOrEmpty(requestDTO.EmployeeType))
                {
                    filteredDemands = filteredDemands.Where(c => c.EmployeeType.ToLower() == requestDTO.EmployeeType.ToLower() || c.Location.ToLower().Contains(requestDTO.EmployeeType.ToLower())).ToList();
                }
                return filteredDemands;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error in SearchCandidates: {ex.Message}");
                throw;
            }
        }

        private List<CandidateDTO> GetCandidates()
        {
            try
            {
                var httpClient = _httpClientFactory.CreateClient();
                httpClient.Timeout = TimeSpan.FromMinutes(5);

                var searchResults = new List<CandidateDTO>();

                var candidateResponse = httpClient.GetAsync("https://localhost:7095/api/Candidate/getcandidatelist").Result;

                if (candidateResponse.IsSuccessStatusCode)
                {
                    candidateResponse.Content.Headers.ContentType = new MediaTypeHeaderValue("application/json");

                    var responseJson = candidateResponse.Content.ReadAsStringAsync().Result;
                    var candidates = JsonConvert.DeserializeObject<List<CandidateDTO>>(responseJson);
                    searchResults.AddRange(candidates);
                }
                else
                {
                    Console.WriteLine("Error in GetAllCandidates: HTTP request failed.");
                }

                return searchResults;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error in GetAllCandidates: {ex.Message}");
                throw; 
            }
        }

        private List<DemandDTO> GetDemands()
        {
            try
            {
                var httpClient = _httpClientFactory.CreateClient();
                httpClient.Timeout = TimeSpan.FromMinutes(5);

                var searchResults = new List<DemandDTO>();

                var candidateResponse = httpClient.GetAsync("https://localhost:7296/api/Demand/getdemandlist").Result;

                if (candidateResponse.IsSuccessStatusCode)
                {
                    candidateResponse.Content.Headers.ContentType = new MediaTypeHeaderValue("application/json");

                    var responseJson = candidateResponse.Content.ReadAsStringAsync().Result;
                    var demands = JsonConvert.DeserializeObject<List<DemandDTO>>(responseJson);
                    searchResults.AddRange(demands);
                }
                else
                {
                    Console.WriteLine("Error in GetAllCandidates: HTTP request failed.");
                }

                return searchResults;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error in GetAllCandidates: {ex.Message}");
                throw;
            }
        }
    }
}
