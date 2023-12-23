namespace TalentToolSystem.Services.Search.DTO
{
    public class CandidateRequestDTO
    {
        public string? Account { get; set; }
        public string? CandidateName { get; set; }
        public string? Manager { get; set; }
        public string? Status { get; set; }
        public string? Location { get; set; }
        public int? ReferralId { get; set; }
    }

}
