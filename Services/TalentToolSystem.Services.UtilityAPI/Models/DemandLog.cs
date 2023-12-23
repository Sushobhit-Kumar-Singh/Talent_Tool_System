using Serilog.Sinks.MSSqlServer;
using System.ComponentModel.DataAnnotations;
using System.Data;

namespace TalentToolSystem.Services.UtilityAPI.Models
{
    public class DemandLog
    {
        //public int? DemandId { get; set; }
        public string DemandName { get; set; }
        public string Email { get; set; }
        public string? AccountName { get; set; }
        public string? Manager { get; set; }
        public int OpenPosition { get; set; } = 0;
        public int? Experience { get; set; }
        public int MaxBudget { get; set; } = 0;
        public int NoticePeriod { get; set; } = 0;
        public string EmployeeType { get; set; }
        public string Status { get; set; }
        public string Location { get; set; }
        public DateTime TimeStamp { get; set; }
           
    }
}
