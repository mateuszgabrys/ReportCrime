using Microsoft.EntityFrameworkCore.Migrations;

namespace LawEnforcement.API.Migrations
{
    public partial class init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CrimeEvents",
                columns: table => new
                {
                    CrimeId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    TypeOfEvent = table.Column<int>(type: "int", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PlaceOfEvent = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ReportingPersonEmail = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Status = table.Column<int>(type: "int", nullable: false),
                    LawEnforcementId = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CrimeEvents", x => x.CrimeId);
                });

            migrationBuilder.CreateTable(
                name: "LawEnfs",
                columns: table => new
                {
                    LawEnfId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    RankOfLawEnforcement = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LawEnfs", x => x.LawEnfId);
                });

            migrationBuilder.CreateTable(
                name: "CrimeEventDto",
                columns: table => new
                {
                    CrimeId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    TypeOfEvent = table.Column<int>(type: "int", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PlaceOfEvent = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ReportingPersonEmail = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Status = table.Column<int>(type: "int", nullable: false),
                    LawEnforcementId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LawEnfId = table.Column<string>(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CrimeEventDto", x => x.CrimeId);
                    table.ForeignKey(
                        name: "FK_CrimeEventDto_LawEnfs_LawEnfId",
                        column: x => x.LawEnfId,
                        principalTable: "LawEnfs",
                        principalColumn: "LawEnfId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                table: "LawEnfs",
                columns: new[] { "LawEnfId", "RankOfLawEnforcement" },
                values: new object[] { "1", 0 });

            migrationBuilder.InsertData(
                table: "LawEnfs",
                columns: new[] { "LawEnfId", "RankOfLawEnforcement" },
                values: new object[] { "2", 2 });

            migrationBuilder.InsertData(
                table: "LawEnfs",
                columns: new[] { "LawEnfId", "RankOfLawEnforcement" },
                values: new object[] { "3", 1 });

            migrationBuilder.CreateIndex(
                name: "IX_CrimeEventDto_LawEnfId",
                table: "CrimeEventDto",
                column: "LawEnfId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CrimeEventDto");

            migrationBuilder.DropTable(
                name: "CrimeEvents");

            migrationBuilder.DropTable(
                name: "LawEnfs");
        }
    }
}
