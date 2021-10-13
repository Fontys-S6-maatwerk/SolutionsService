using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace SolutionsService.Migrations
{
    public partial class init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "SDG",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SDGNumber = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SDG", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Solution",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    WeatherExtreme = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SolutionType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    HeaderImageURL = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Content = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Difficulty = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ImpactGoal = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CurrentImpact = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AuthorId = table.Column<long>(type: "bigint", nullable: false),
                    UploadDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ViewCount = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Solution", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "SDGSolution",
                columns: table => new
                {
                    SDGsId = table.Column<long>(type: "bigint", nullable: false),
                    SolutionsId = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SDGSolution", x => new { x.SDGsId, x.SolutionsId });
                    table.ForeignKey(
                        name: "FK_SDGSolution_SDG_SDGsId",
                        column: x => x.SDGsId,
                        principalTable: "SDG",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_SDGSolution_Solution_SolutionsId",
                        column: x => x.SolutionsId,
                        principalTable: "Solution",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_SDGSolution_SolutionsId",
                table: "SDGSolution",
                column: "SolutionsId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "SDGSolution");

            migrationBuilder.DropTable(
                name: "SDG");

            migrationBuilder.DropTable(
                name: "Solution");
        }
    }
}
