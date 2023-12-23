using Serilog.Sinks.MSSqlServer;
using Serilog;
using System.Data;
using TalentToolSystem.Services.UtilityAPI.Models;

namespace TalentToolSystem.Services.UtilityAPI.Logger
{
    public class CustomLogger
    {
        static CustomLogger()
        {
            var sinkOptions = new MSSqlServerSinkOptions()
            {
                TableName = "LocationLog",
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
                new SqlColumn { DataType = SqlDbType.Int, ColumnName = "LocationId", AllowNull = false},
                new SqlColumn { DataType = SqlDbType.VarChar, ColumnName = "City",DataLength = 50, AllowNull = false },
                new SqlColumn { DataType = SqlDbType.VarChar, ColumnName = "State", DataLength = 50, AllowNull = false },
                new SqlColumn { DataType = SqlDbType.DateTime2, ColumnName = "TimeStamp", AllowNull = false },
            };
            return columnOptions;
        }

        public static void Information(Location location)
        {
            if (location == null)
            {
                Log.Logger.Error("Object reference not set to an instance of an object.");
            }
            else
            {
                Log.Logger.Information("{LocationId}{City}{State}{TimeStamp}", location.LocationId, location.City, location.State, DateTime.Now);
            }

        }
    }
}
