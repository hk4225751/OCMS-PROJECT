using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace OCMS_project.Migrations
{
    public partial class seeddatauseraccount : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "UserCreadentials",
                columns: new[] { "CreadId", "Password", "UserId" },
                values: new object[] { new Guid("bf748478-12c3-44e9-bd8e-30a4637b5f2d"), "Admin123", new Guid("6f07938b-3ceb-479a-99e7-f375bf2e84d4") });

            migrationBuilder.InsertData(
                table: "UserRoles",
                columns: new[] { "UserRoleId", "UserId", "UserRole" },
                values: new object[] { new Guid("b9040149-6ee0-4492-93b6-aad8d512da52"), new Guid("6f07938b-3ceb-479a-99e7-f375bf2e84d4"), 0 });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "UserId", "AccountStatus", "Address", "ContactNum", "Email", "FullName", "ImageUrl", "Password", "UserName" },
                values: new object[] { new Guid("6f07938b-3ceb-479a-99e7-f375bf2e84d4"), 0, null, null, "Admin@gmail.com", "Admin", null, "Admin@123", "Admin" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "UserCreadentials",
                keyColumn: "CreadId",
                keyValue: new Guid("bf748478-12c3-44e9-bd8e-30a4637b5f2d"));

            migrationBuilder.DeleteData(
                table: "UserRoles",
                keyColumn: "UserRoleId",
                keyValue: new Guid("b9040149-6ee0-4492-93b6-aad8d512da52"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: new Guid("6f07938b-3ceb-479a-99e7-f375bf2e84d4"));
        }
    }
}
