using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace TalentToolSystem.Services.CandidateAPI.Migrations
{
    /// <inheritdoc />
    public partial class initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Candidates",
                columns: table => new
                {
                    CandidateId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CandidateName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Mobile = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CurrentCompany = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SkillSet = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    YearOfExperience = table.Column<int>(type: "int", nullable: false),
                    Location = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CTC = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    ECTC = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    NoticePeriod = table.Column<int>(type: "int", nullable: false),
                    ReferralId = table.Column<int>(type: "int", nullable: false),
                    Status = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Manager = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Account = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Candidates", x => x.CandidateId);
                });

            migrationBuilder.InsertData(
                table: "Candidates",
                columns: new[] { "CandidateId", "Account", "CTC", "CandidateName", "CurrentCompany", "ECTC", "Email", "Location", "Manager", "Mobile", "NoticePeriod", "ReferralId", "SkillSet", "Status", "YearOfExperience" },
                values: new object[,]
                {
                    { 1, "Salesforce", 10m, "Indresh Kumar Maurya", "Nexturn", 10m, "indresh@gmail.com", "Mirzapur", "Gunjan", "7823637281", 10, 101, "C++,.Net,Sql Server", "Selected", 1 },
                    { 2, "Salesforce", 10m, "Shobhit Kumar Singh", "Nexturn", 10m, "shobhit@gmail.com", "Patna", "Gunjan", "7823637281", 10, 101, "C++,.Net,Sql Server", "Selected", 1 },
                    { 3, "Amazon", 10m, "Abuzar Nasim", "Nexturn", 10m, "abuzar@gmail.com", "Ranchi", "Gunjan", "7823637281", 10, 101, "C++,.Net,Sql Server", "Selected", 1 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Candidates");
        }
    }
}
