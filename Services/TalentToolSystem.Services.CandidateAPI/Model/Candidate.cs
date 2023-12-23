using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace TalentToolSystem.Services.CandidateAPI.Model
{
    public class Candidate
    {  
        [Key]
        public int CandidateId { get; set; }
        [Required]
        public string CandidateName { get; set; }
        [Required]
        /* [EmailAddress]*/
        [RegularExpression(@"^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$", ErrorMessage = "Invalid email address.")]
        public string Email { get; set; }
        [Required]
        [RegularExpression(@"^\d{10}$", ErrorMessage = "Exactly 10 digits are allowed.")]
        public string Mobile { get; set; }
        public string CurrentCompany { get; set; }
        public string SkillSet { get; set; } = null!;
        public int YearOfExperience { get; set; }
        public string Location { get; set; }
        public decimal CTC { get; set; }
        public decimal ECTC { get; set; }
        public int NoticePeriod { get; set; }
        public int ReferralId { get; set; }
        public string Status { get; set; }
        public string Manager { get; set; }
        public string Account { get; set; }
    }
}
