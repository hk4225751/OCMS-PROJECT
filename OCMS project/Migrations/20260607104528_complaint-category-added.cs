using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace OCMS_project.Migrations
{
    public partial class complaintcategoryadded : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Categories",
                columns: table => new
                {
                    Cat_Id = table.Column<Guid>(nullable: false),
                    Cat_Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.Cat_Id);
                });

            migrationBuilder.CreateTable(
                name: "Complaints",
                columns: table => new
                {
                    Complaint_Id = table.Column<Guid>(nullable: false),
                    Complaint_Title = table.Column<string>(nullable: true),
                    Cat_Id = table.Column<Guid>(nullable: false),
                    Complaint_Description = table.Column<string>(nullable: true),
                    ComplaintImageURL = table.Column<string>(nullable: true),
                    ComplaintDate = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Complaints", x => x.Complaint_Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Categories");

            migrationBuilder.DropTable(
                name: "Complaints");
        }
    }
}
