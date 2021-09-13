using Microsoft.EntityFrameworkCore.Migrations;

namespace web_api_pract.Migrations
{
    public partial class add_devloper : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Project_Devlopers_Devloper_DevloperId",
                table: "Project_Devlopers");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Devloper",
                table: "Devloper");

            migrationBuilder.RenameTable(
                name: "Devloper",
                newName: "Devlopers");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Devlopers",
                table: "Devlopers",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Project_Devlopers_Devlopers_DevloperId",
                table: "Project_Devlopers",
                column: "DevloperId",
                principalTable: "Devlopers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Project_Devlopers_Devlopers_DevloperId",
                table: "Project_Devlopers");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Devlopers",
                table: "Devlopers");

            migrationBuilder.RenameTable(
                name: "Devlopers",
                newName: "Devloper");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Devloper",
                table: "Devloper",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Project_Devlopers_Devloper_DevloperId",
                table: "Project_Devlopers",
                column: "DevloperId",
                principalTable: "Devloper",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
