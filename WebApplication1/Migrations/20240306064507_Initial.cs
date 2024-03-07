using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace UniversityRankingAPI.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Location",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    city = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    country = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    region = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Location", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "UniversityData",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    university = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    rank_display = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    score = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    type = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    student_faculty_ratio = table.Column<int>(type: "int", nullable: false),
                    international_students = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    faculty_count = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    locationId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UniversityData", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UniversityData_Location_locationId",
                        column: x => x.locationId,
                        principalTable: "Location",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_UniversityData_locationId",
                table: "UniversityData",
                column: "locationId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "UniversityData");

            migrationBuilder.DropTable(
                name: "Location");
        }
    }
}
