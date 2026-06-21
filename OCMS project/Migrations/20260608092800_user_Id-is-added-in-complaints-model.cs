using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace OCMS_project.Migrations
{
    public partial class user_Idisaddedincomplaintsmodel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "User_Id",
                table: "Complaints",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "User_Id",
                table: "Complaints");
        }
    }
}
