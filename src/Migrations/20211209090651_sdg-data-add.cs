using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace SolutionsService.Migrations
{
    public partial class sdgdataadd : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "SDGs",
                columns: new[] { "Id", "Name", "SDGNumber" },
                values: new object[,]
                {
                    { new Guid("feb4e7c8-9dd4-4b9b-82f3-499d0b464a2b"), "No poverty", 1 },
                    { new Guid("9d6f8727-bc53-4818-8d0c-0e334555663f"), "Life on land", 15 },
                    { new Guid("3624d854-8c88-4023-92b8-134a99d25f6d"), "Life below water", 14 },
                    { new Guid("e1a1894f-a631-4066-8852-703cba2c33c2"), "Climate action", 13 },
                    { new Guid("d8821681-a681-4d19-be44-af404b3181c5"), "Responsible consumption and production", 12 },
                    { new Guid("9c4d0ab6-39f1-4fdb-a5e8-117691959c28"), "Sustainable cities and communities", 11 },
                    { new Guid("d49d23c5-aa11-4fcf-b65e-68d71d9a91e5"), "Reducted inequalities", 10 },
                    { new Guid("0e1a9682-3632-48ae-8abe-e7c2f1c7da75"), "Peace justice and strong institutions", 16 },
                    { new Guid("caaa5420-ebe1-45d7-966f-61c5071a3669"), "Industry, innovation and infrastructure", 9 },
                    { new Guid("f79bc0bb-6e2d-4cb2-bc2b-22cda995bf81"), "Affordable and clean energy", 7 },
                    { new Guid("764df34b-2395-4b4e-9434-97109ec8dd6a"), "Clean water and sanitation", 6 },
                    { new Guid("d0e263f0-4e3b-4fd0-90f4-07753263bd6e"), "Gender equality", 5 },
                    { new Guid("2ff25e4b-c275-4c90-afd4-f42c4ee3197f"), "Quality education", 4 },
                    { new Guid("27db908e-b607-4454-9259-8ac399a4cc3f"), "Good health and well-being", 3 },
                    { new Guid("9c46504c-7bb9-472e-bc9e-7da9957f34cc"), "Zero hunger", 2 },
                    { new Guid("7faa4d47-0a98-4750-9c1e-5ca95799cb16"), "Decent work and economic growth", 8 },
                    { new Guid("50e63213-7243-4232-bb6b-14bccb665341"), "Partnerships for the goals", 17 }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "SDGs",
                keyColumn: "Id",
                keyValue: new Guid("0e1a9682-3632-48ae-8abe-e7c2f1c7da75"));

            migrationBuilder.DeleteData(
                table: "SDGs",
                keyColumn: "Id",
                keyValue: new Guid("27db908e-b607-4454-9259-8ac399a4cc3f"));

            migrationBuilder.DeleteData(
                table: "SDGs",
                keyColumn: "Id",
                keyValue: new Guid("2ff25e4b-c275-4c90-afd4-f42c4ee3197f"));

            migrationBuilder.DeleteData(
                table: "SDGs",
                keyColumn: "Id",
                keyValue: new Guid("3624d854-8c88-4023-92b8-134a99d25f6d"));

            migrationBuilder.DeleteData(
                table: "SDGs",
                keyColumn: "Id",
                keyValue: new Guid("50e63213-7243-4232-bb6b-14bccb665341"));

            migrationBuilder.DeleteData(
                table: "SDGs",
                keyColumn: "Id",
                keyValue: new Guid("764df34b-2395-4b4e-9434-97109ec8dd6a"));

            migrationBuilder.DeleteData(
                table: "SDGs",
                keyColumn: "Id",
                keyValue: new Guid("7faa4d47-0a98-4750-9c1e-5ca95799cb16"));

            migrationBuilder.DeleteData(
                table: "SDGs",
                keyColumn: "Id",
                keyValue: new Guid("9c46504c-7bb9-472e-bc9e-7da9957f34cc"));

            migrationBuilder.DeleteData(
                table: "SDGs",
                keyColumn: "Id",
                keyValue: new Guid("9c4d0ab6-39f1-4fdb-a5e8-117691959c28"));

            migrationBuilder.DeleteData(
                table: "SDGs",
                keyColumn: "Id",
                keyValue: new Guid("9d6f8727-bc53-4818-8d0c-0e334555663f"));

            migrationBuilder.DeleteData(
                table: "SDGs",
                keyColumn: "Id",
                keyValue: new Guid("caaa5420-ebe1-45d7-966f-61c5071a3669"));

            migrationBuilder.DeleteData(
                table: "SDGs",
                keyColumn: "Id",
                keyValue: new Guid("d0e263f0-4e3b-4fd0-90f4-07753263bd6e"));

            migrationBuilder.DeleteData(
                table: "SDGs",
                keyColumn: "Id",
                keyValue: new Guid("d49d23c5-aa11-4fcf-b65e-68d71d9a91e5"));

            migrationBuilder.DeleteData(
                table: "SDGs",
                keyColumn: "Id",
                keyValue: new Guid("d8821681-a681-4d19-be44-af404b3181c5"));

            migrationBuilder.DeleteData(
                table: "SDGs",
                keyColumn: "Id",
                keyValue: new Guid("e1a1894f-a631-4066-8852-703cba2c33c2"));

            migrationBuilder.DeleteData(
                table: "SDGs",
                keyColumn: "Id",
                keyValue: new Guid("f79bc0bb-6e2d-4cb2-bc2b-22cda995bf81"));

            migrationBuilder.DeleteData(
                table: "SDGs",
                keyColumn: "Id",
                keyValue: new Guid("feb4e7c8-9dd4-4b9b-82f3-499d0b464a2b"));
        }
    }
}
