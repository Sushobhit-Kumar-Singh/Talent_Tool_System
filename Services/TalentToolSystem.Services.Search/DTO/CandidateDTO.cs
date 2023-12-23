namespace TalentToolSystem.Services.Search.DTO
{
    public class CandidateDTO
    {
        public int CandidateId { get; set; }
        public string CandidateName { get; set; }
        public string Email { get; set; }
        public string Mobile { get; set; }
        public string CurrentCompany { get; set; }
        public string SkillSet { get; set; } = null!;
        public int YearOfExperience { get; set; }
        public string Location { get; set; }
        public decimal CTC { get; set; }
        public decimal ECTC { get; set; }
        public int NoticePeriod { get; set; }
        public int ReferralId { get; set; }
        public string Manager { get; set; }
        public string Account { get; set; }
        public string Status { get; set; }
    }
}
