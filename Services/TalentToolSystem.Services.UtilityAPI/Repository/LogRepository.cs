using Microsoft.Data.SqlClient;
using Serilog;
using System.Data.Common;
using System.Dynamic;
using TalentToolSystem.Services.UtilityAPI.Models;

namespace TalentToolSystem.Services.UtilityAPI.Repository
{
    public class LogRepository : ILogRepository
    {
        private readonly IConfiguration configuration;
        private readonly string dbconnection;
        private readonly string dateformat;

        public LogRepository(IConfiguration configuration)
        {
            this.configuration = configuration;
            dbconnection = this.configuration["ConnectionStrings:UtilityConnection"];
            //dateformat = this.configuration["Constants:DateFormat"];
        }
        public async Task<IEnumerable<CandidateLog>> GetAllCandidateLogs()
        {
            var logs = new List<CandidateLog>();
            using (SqlConnection connection = new(dbconnection))
            {
                SqlCommand command = new()
                {
                    Connection = connection,
                };

                string query = "SELECT * FROM CandidateLog";
                command.CommandText = query;
                
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    var log = new CandidateLog()
                    {
                        CandidateId = (int)reader["CandidateId"],
                        CandidateName = (string)reader["CandidateName"],
                        Email = (string)reader["Email"],
                        Mobile = (string)reader["Mobile"],
                        CurrentCompany = (string)reader["CurrentCompany"],
                        Experience = (int)reader["Experience"],
                        Location = (string)reader["Location"],
                        CTC = (Decimal)reader["CTC"],
                        ECTC = (Decimal)reader["ECTC"],
                        NoticePeriod = (int)reader["NoticePeriod"],
                        ReferralId = (int)reader["ReferralId"],
                        Status = (string)reader["Status"],
                        Manager = (string)reader["Status"],
                        Account = (string)reader["Status"],
                        TimeStamp = (DateTime)reader["TimeStamp"],
                    };
                    logs.Add(log);
                }
            }
            return logs;
        }

        public async Task<IEnumerable<DemandLog>> GetAllDemandLogs()
        {
            var logs = new List<DemandLog>();
            using (SqlConnection connection = new(dbconnection))
            {
                SqlCommand command = new()
                {
                    Connection = connection,
                };

                string query = "SELECT * FROM DemandLog";
                command.CommandText = query;

                connection.Open();
                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    var log = new DemandLog()
                    {
                        DemandName = (string)reader["DemandName"],
                        Email = (string)reader["Email"],
                        AccountName = (string)reader["AccountName"],
                        Manager = (string)reader["Manager"],
                        OpenPosition = (int)reader["OpenPosition"],
                        Experience = (int)reader["Experience"],
                        MaxBudget = (int)reader["MaxBudget"],
                        NoticePeriod = (int)reader["NoticePeriod"],
                        EmployeeType = (string)reader["EmployeeType"],
                        Status = (string)reader["Status"],
                        Location = (string)reader["Location"],
                        TimeStamp = (DateTime)reader["TimeStamp"],
                    };
                    logs.Add(log);
                }
            }
            return logs;
        }
    }
}
