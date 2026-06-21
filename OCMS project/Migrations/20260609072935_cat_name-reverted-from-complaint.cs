using Microsoft.EntityFrameworkCore.Migrations;

namespace OCMS_project.Migrations
{
    public partial class cat_namerevertedfromcomplaint : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Cat_Name",
                table: "Complaints");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Cat_Name",
                table: "Complaints",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
