using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace SolutionsService.Migrations
{
    public partial class manytomanyentity : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "SDGSolution");

            migrationBuilder.CreateTable(
                name: "SDGSolutions",
                columns: table => new
                {
                    SolutionId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    SDGId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SDGSolutions", x => new { x.SDGId, x.SolutionId });
                    table.ForeignKey(
                        name: "FK_SDGSolutions_SDGs_SDGId",
                        column: x => x.SDGId,
                        principalTable: "SDGs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_SDGSolutions_Solutions_SolutionId",
                        column: x => x.SolutionId,
                        principalTable: "Solutions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_SDGSolutions_SolutionId",
                table: "SDGSolutions",
                column: "SolutionId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "SDGSolutions");

            migrationBuilder.CreateTable(
                name: "SDGSolution",
                columns: table => new
                {
                    SDGsId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    SolutionsId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SDGSolution", x => new { x.SDGsId, x.SolutionsId });
                    table.ForeignKey(
                        name: "FK_SDGSolution_SDGs_SDGsId",
                        column: x => x.SDGsId,
                        principalTable: "SDGs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_SDGSolution_Solutions_SolutionsId",
                        column: x => x.SolutionsId,
                        principalTable: "Solutions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_SDGSolution_SolutionsId",
                table: "SDGSolution",
                column: "SolutionsId");
        }
    }
}
