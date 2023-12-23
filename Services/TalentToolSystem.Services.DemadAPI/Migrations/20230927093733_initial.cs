using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace TalentToolSystem.Services.DemandAPI.Migrations
{
    /// <inheritdoc />
    public partial class initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "demands",
                columns: table => new
                {
                    DemandId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DemandName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AccountName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Manager = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    OpenPosition = table.Column<int>(type: "int", nullable: false),
                    Experience = table.Column<int>(type: "int", nullable: true),
                    MaxBudget = table.Column<int>(type: "int", nullable: false),
                    NoticePeriod = table.Column<int>(type: "int", nullable: false),
                    EmployeeType = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Status = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Skills = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Location = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_demands", x => x.DemandId);
                });

            migrationBuilder.InsertData(
                table: "demands",
                columns: new[] { "DemandId", "AccountName", "DemandName", "Email", "EmployeeType", "Experience", "Location", "Manager", "MaxBudget", "NoticePeriod", "OpenPosition", "Skills", "Status" },
                values: new object[,]
                {
                    { 1, "Amazon", "Python Developer", "nexturn@gmail.com", "FTE", 1, "Hyderabad", "Gunjan", 10, 2, 1, "Python, Relationa Database", "Selected" },
                    { 2, "Amazon", "Java Developer", "nexturn@gmail.com", "FTE", 1, "Hyderabad", "Gunjan", 10, 2, 1, "Python, Relationa Database", "Selected" },
                    { 3, "Amazon", ".Net Developer", "nexturn@gmail.com", "FTE", 1, "Hyderabad", "Gunjan", 10, 2, 1, "Python, Relationa Database", "Selected" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "demands");
        }
    }
}
