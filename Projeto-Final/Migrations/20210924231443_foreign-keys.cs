using Microsoft.EntityFrameworkCore.Migrations;

namespace Projeto_Final.Migrations
{
    public partial class foreignkeys : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "User_Id",
                table: "Photos");

            migrationBuilder.DropColumn(
                name: "New_owner_id",
                table: "Pets");

            migrationBuilder.DropColumn(
                name: "Old_owner_id",
                table: "Pets");

            migrationBuilder.AddColumn<int>(
                name: "New_ownerId",
                table: "Pets",
                type: "integer",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Pets_New_ownerId",
                table: "Pets",
                column: "New_ownerId");

            migrationBuilder.AddForeignKey(
                name: "FK_Pets_Users_New_ownerId",
                table: "Pets",
                column: "New_ownerId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Pets_Users_New_ownerId",
                table: "Pets");

            migrationBuilder.DropIndex(
                name: "IX_Pets_New_ownerId",
                table: "Pets");

            migrationBuilder.DropColumn(
                name: "New_ownerId",
                table: "Pets");

            migrationBuilder.AddColumn<int>(
                name: "User_Id",
                table: "Photos",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "New_owner_id",
                table: "Pets",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Old_owner_id",
                table: "Pets",
                type: "text",
                nullable: true);
        }
    }
}
