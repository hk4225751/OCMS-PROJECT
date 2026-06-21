using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace OCMS_project.Migrations
{
    public partial class seeddataincategory : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Cat_Id", "Cat_Name" },
                values: new object[,]
                {
                    { new Guid("7fbed69c-e942-456a-82bb-fdb9457dd30e"), "Water Leakage" },
                    { new Guid("0e0625d6-d7f9-4c1b-b26c-e5dc239e5938"), "Eelectricity" },
                    { new Guid("7a659b16-bcb1-4e9f-bc74-a7ed6e5c0cb7"), "Air Conditioner" },
                    { new Guid("5d1ead8f-bb23-489e-b09a-35380986b92b"), "Office Kitchen" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Cat_Id",
                keyValue: new Guid("0e0625d6-d7f9-4c1b-b26c-e5dc239e5938"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Cat_Id",
                keyValue: new Guid("5d1ead8f-bb23-489e-b09a-35380986b92b"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Cat_Id",
                keyValue: new Guid("7a659b16-bcb1-4e9f-bc74-a7ed6e5c0cb7"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Cat_Id",
                keyValue: new Guid("7fbed69c-e942-456a-82bb-fdb9457dd30e"));
        }
    }
}
