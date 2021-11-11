using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace SolutionsService.Migrations
{
    public partial class modelUpdateRTR : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Like_Solution_SolutionId",
                table: "Like");

            migrationBuilder.DropForeignKey(
                name: "FK_SDGSolution_SDG_SDGsId",
                table: "SDGSolution");

            migrationBuilder.DropForeignKey(
                name: "FK_SDGSolution_Solution_SolutionsId",
                table: "SDGSolution");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Solution",
                table: "Solution");

            migrationBuilder.DropPrimaryKey(
                name: "PK_SDG",
                table: "SDG");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Like",
                table: "Like");

            migrationBuilder.DropColumn(
                name: "Content",
                table: "Solution");

            migrationBuilder.DropColumn(
                name: "CurrentImpact",
                table: "Solution");

            migrationBuilder.DropColumn(
                name: "ImpactGoal",
                table: "Solution");

            migrationBuilder.RenameTable(
                name: "Solution",
                newName: "Solutions");

            migrationBuilder.RenameTable(
                name: "SDG",
                newName: "SDGs");

            migrationBuilder.RenameTable(
                name: "Like",
                newName: "Likes");

            migrationBuilder.RenameColumn(
                name: "SolutionType",
                table: "Solutions",
                newName: "Introduction");

            migrationBuilder.RenameIndex(
                name: "IX_Like_SolutionId",
                table: "Likes",
                newName: "IX_Likes_SolutionId");

            migrationBuilder.AlterColumn<int>(
                name: "ViewCount",
                table: "Solutions",
                type: "int",
                nullable: false,
                oldClrType: typeof(long),
                oldType: "bigint");

            migrationBuilder.AddColumn<string>(
                name: "Discriminator",
                table: "Solutions",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<DateTime>(
                name: "LastUpdatedTime",
                table: "Solutions",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddPrimaryKey(
                name: "PK_Solutions",
                table: "Solutions",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_SDGs",
                table: "SDGs",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Likes",
                table: "Likes",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "Materials",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SolutionId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Materials", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Materials_Solutions_SolutionId",
                        column: x => x.SolutionId,
                        principalTable: "Solutions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Steps",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CoverImage = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SolutionId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Steps", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Steps_Solutions_SolutionId",
                        column: x => x.SolutionId,
                        principalTable: "Solutions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Tools",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    HowToId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tools", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Tools_Solutions_HowToId",
                        column: x => x.HowToId,
                        principalTable: "Solutions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Materials_SolutionId",
                table: "Materials",
                column: "SolutionId");

            migrationBuilder.CreateIndex(
                name: "IX_Steps_SolutionId",
                table: "Steps",
                column: "SolutionId");

            migrationBuilder.CreateIndex(
                name: "IX_Tools_HowToId",
                table: "Tools",
                column: "HowToId");

            migrationBuilder.AddForeignKey(
                name: "FK_Likes_Solutions_SolutionId",
                table: "Likes",
                column: "SolutionId",
                principalTable: "Solutions",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_SDGSolution_SDGs_SDGsId",
                table: "SDGSolution",
                column: "SDGsId",
                principalTable: "SDGs",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_SDGSolution_Solutions_SolutionsId",
                table: "SDGSolution",
                column: "SolutionsId",
                principalTable: "Solutions",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Likes_Solutions_SolutionId",
                table: "Likes");

            migrationBuilder.DropForeignKey(
                name: "FK_SDGSolution_SDGs_SDGsId",
                table: "SDGSolution");

            migrationBuilder.DropForeignKey(
                name: "FK_SDGSolution_Solutions_SolutionsId",
                table: "SDGSolution");

            migrationBuilder.DropTable(
                name: "Materials");

            migrationBuilder.DropTable(
                name: "Steps");

            migrationBuilder.DropTable(
                name: "Tools");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Solutions",
                table: "Solutions");

            migrationBuilder.DropPrimaryKey(
                name: "PK_SDGs",
                table: "SDGs");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Likes",
                table: "Likes");

            migrationBuilder.DropColumn(
                name: "Discriminator",
                table: "Solutions");

            migrationBuilder.DropColumn(
                name: "LastUpdatedTime",
                table: "Solutions");

            migrationBuilder.RenameTable(
                name: "Solutions",
                newName: "Solution");

            migrationBuilder.RenameTable(
                name: "SDGs",
                newName: "SDG");

            migrationBuilder.RenameTable(
                name: "Likes",
                newName: "Like");

            migrationBuilder.RenameColumn(
                name: "Introduction",
                table: "Solution",
                newName: "SolutionType");

            migrationBuilder.RenameIndex(
                name: "IX_Likes_SolutionId",
                table: "Like",
                newName: "IX_Like_SolutionId");

            migrationBuilder.AlterColumn<long>(
                name: "ViewCount",
                table: "Solution",
                type: "bigint",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<string>(
                name: "Content",
                table: "Solution",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CurrentImpact",
                table: "Solution",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ImpactGoal",
                table: "Solution",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Solution",
                table: "Solution",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_SDG",
                table: "SDG",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Like",
                table: "Like",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Like_Solution_SolutionId",
                table: "Like",
                column: "SolutionId",
                principalTable: "Solution",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_SDGSolution_SDG_SDGsId",
                table: "SDGSolution",
                column: "SDGsId",
                principalTable: "SDG",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_SDGSolution_Solution_SolutionsId",
                table: "SDGSolution",
                column: "SolutionsId",
                principalTable: "Solution",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
