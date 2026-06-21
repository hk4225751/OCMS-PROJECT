using Microsoft.EntityFrameworkCore.Migrations;

namespace OCMS_project.Migrations
{
    public partial class trackstatusenumadded : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "status",
                table: "Complaints",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "status",
                table: "Complaints");
        }
    }
}
