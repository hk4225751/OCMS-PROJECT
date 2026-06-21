using Microsoft.EntityFrameworkCore.Migrations;

namespace OCMS_project.Migrations
{
    public partial class navigationalvirtualclassaddedin0complaintmodel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_Complaints_Cat_Id",
                table: "Complaints",
                column: "Cat_Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Complaints_Categories_Cat_Id",
                table: "Complaints",
                column: "Cat_Id",
                principalTable: "Categories",
                principalColumn: "Cat_Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Complaints_Categories_Cat_Id",
                table: "Complaints");

            migrationBuilder.DropIndex(
                name: "IX_Complaints_Cat_Id",
                table: "Complaints");
        }
    }
}
