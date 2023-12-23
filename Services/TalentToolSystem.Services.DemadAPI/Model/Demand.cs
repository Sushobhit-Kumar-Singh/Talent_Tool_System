using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace TalentToolSystem.Services.DemandAPI.Model
{
    public class Demand
    {
        [Key]
        public int? DemandId { get; set; }

        [Required]
        public string DemandName { get; set; } = "";

        [Required]
        [RegularExpression(@"^[a-zA-Z0-9_.+-]+@[a-zA-Z0-9-]+\.[a-zA-Z0-9-.]+$",
            ErrorMessage ="Invalid Email Format")]
        public string Email { get; set; } = "";
        public string? AccountName { get; set; }

        public string? Manager { get; set; }
        public int OpenPosition { get; set; } = 0;
        public int? Experience { get; set; }
        public int MaxBudget { get; set; } = 0;
        public int NoticePeriod { get; set; } = 0;
        public string EmployeeType { get; set; } = "";
        public string Status { get; set; } = "";
        public string Skills { get; set; } = null!;
        public string Location { get; set; } = "";
    }
}
