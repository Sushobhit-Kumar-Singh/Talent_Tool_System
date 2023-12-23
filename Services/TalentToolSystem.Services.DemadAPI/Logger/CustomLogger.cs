using Serilog.Sinks.MSSqlServer;
using Serilog;
using System.Data;
using TalentToolSystem.Services.DemandAPI.Model;

namespace TalentToolSystem.Services.UtilityAPI.Logger
{
    public class CustomLogger
    {
        static CustomLogger()
        {
            var sinkOptions = new MSSqlServerSinkOptions()
            {
                TableName = "DemandLog",
                AutoCreateSqlTable = true
            };
            var connectionString = "Data Source=LAPTOP-A8AG81M8\\SQLEXPRESS;Initial Catalog=UtilityDb;Integrated Security=True;TrustServerCertificate=True;";

            Log.Logger = new LoggerConfiguration()
           .MinimumLevel.Information()
           .WriteTo.MSSqlServer(connectionString, sinkOptions, null, null,
            Serilog.Events.LogEventLevel.Information, columnOptions: GetColumnOptions())
           .CreateLogger();
        }


        public static ColumnOptions GetColumnOptions()
        {
            var columnOptions = new ColumnOptions();

            // Override the default Primary Column of Serilog by custom column name
            columnOptions.Id.ColumnName = "LogId";


            // Removing all the default column
            columnOptions.Store.Remove(StandardColumn.TimeStamp);
            columnOptions.Store.Remove(StandardColumn.Message);
            columnOptions.Store.Remove(StandardColumn.Level);
            columnOptions.Store.Remove(StandardColumn.Exception);
            columnOptions.Store.Remove(StandardColumn.MessageTemplate);
            columnOptions.Store.Remove(StandardColumn.Properties);


            // Adding all the custom columns
            columnOptions.AdditionalColumns = new List<SqlColumn>
            {
                //new SqlColumn { DataType = SqlDbType.Int, ColumnName = "DemandId", AllowNull = false},
                new SqlColumn { DataType = SqlDbType.VarChar, ColumnName = "DemandName",DataLength = 50, AllowNull = false },
                new SqlColumn { DataType = SqlDbType.VarChar, ColumnName = "Email", DataLength = 50, AllowNull = false },
                new SqlColumn { DataType = SqlDbType.VarChar, ColumnName = "AccountName", DataLength = 50, AllowNull = false },
                new SqlColumn { DataType = SqlDbType.VarChar, ColumnName = "Manager", DataLength = 50, AllowNull = false },
                new SqlColumn { DataType = SqlDbType.Int, ColumnName = "OpenPosition", AllowNull = false },
                new SqlColumn { DataType = SqlDbType.Int, ColumnName = "Experience", AllowNull = false },
                new SqlColumn { DataType = SqlDbType.Int, ColumnName = "MaxBudget", AllowNull = false },
                new SqlColumn { DataType = SqlDbType.Int, ColumnName = "NoticePeriod", AllowNull = false },
                new SqlColumn { DataType = SqlDbType.VarChar, ColumnName = "EmployeeType", DataLength = 50, AllowNull = false },
                new SqlColumn { DataType = SqlDbType.VarChar, ColumnName = "Status", DataLength = 50, AllowNull = false },
                new SqlColumn { DataType = SqlDbType.VarChar, ColumnName = "Location", DataLength = 50, AllowNull = false },
                new SqlColumn { DataType = SqlDbType.DateTime2, ColumnName = "TimeStamp", AllowNull = false },
            };
            return columnOptions;
        }

        public static void Information(Demand demand)
        {
            if (demand == null)
            {
                Log.Logger.Error("Object reference not set to an instance of an object.");
            }
            else
            {
                Log.Logger.Information("{DemandName}{Email}{AccountName}{Manager}{OpenPosition}{Experience}{MaxBudget}{NoticePeriod}{EmployeeType}{Status}{Location}{TimeStamp}",
                    demand.DemandName, demand.Email, demand.AccountName, demand.Manager,
                    demand.OpenPosition, demand.Experience, demand.MaxBudget, demand.NoticePeriod,
                    demand.EmployeeType, demand.Status, demand.Location, DateTime.Now
                    );
            }

        }
    }
}