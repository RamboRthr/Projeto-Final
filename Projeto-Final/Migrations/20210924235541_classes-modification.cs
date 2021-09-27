using Microsoft.EntityFrameworkCore.Migrations;

namespace Projeto_Final.Migrations
{
    public partial class classesmodification : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Pets_Users_New_ownerId",
                table: "Pets");

            migrationBuilder.DropColumn(
                name: "Pet_name",
                table: "Photos");

            migrationBuilder.RenameColumn(
                name: "PhotoURL",
                table: "Photos",
                newName: "PhotoPath");

            migrationBuilder.RenameColumn(
                name: "New_ownerId",
                table: "Pets",
                newName: "Current_ownerId");

            migrationBuilder.RenameIndex(
                name: "IX_Pets_New_ownerId",
                table: "Pets",
                newName: "IX_Pets_Current_ownerId");

            migrationBuilder.AddForeignKey(
                name: "FK_Pets_Users_Current_ownerId",
                table: "Pets",
                column: "Current_ownerId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Pets_Users_Current_ownerId",
                table: "Pets");

            migrationBuilder.RenameColumn(
                name: "PhotoPath",
                table: "Photos",
                newName: "PhotoURL");

            migrationBuilder.RenameColumn(
                name: "Current_ownerId",
                table: "Pets",
                newName: "New_ownerId");

            migrationBuilder.RenameIndex(
                name: "IX_Pets_Current_ownerId",
                table: "Pets",
                newName: "IX_Pets_New_ownerId");

            migrationBuilder.AddColumn<string>(
                name: "Pet_name",
                table: "Photos",
                type: "text",
                nullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Pets_Users_New_ownerId",
                table: "Pets",
                column: "New_ownerId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
