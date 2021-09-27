using Microsoft.EntityFrameworkCore.Migrations;

namespace Projeto_Final.Migrations
{
    public partial class v2409 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "New_owner_id",
                table: "Pets");

            migrationBuilder.DropColumn(
                name: "Old_owner_id",
                table: "Pets");

            migrationBuilder.AddColumn<int>(
                name: "New_owner_idId",
                table: "Pets",
                type: "integer",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Old_owner_idId",
                table: "Pets",
                type: "integer",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Pets_New_owner_idId",
                table: "Pets",
                column: "New_owner_idId");

            migrationBuilder.CreateIndex(
                name: "IX_Pets_Old_owner_idId",
                table: "Pets",
                column: "Old_owner_idId");

            migrationBuilder.AddForeignKey(
                name: "FK_Pets_Users_New_owner_idId",
                table: "Pets",
                column: "New_owner_idId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Pets_Users_Old_owner_idId",
                table: "Pets",
                column: "Old_owner_idId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Pets_Users_New_owner_idId",
                table: "Pets");

            migrationBuilder.DropForeignKey(
                name: "FK_Pets_Users_Old_owner_idId",
                table: "Pets");

            migrationBuilder.DropIndex(
                name: "IX_Pets_New_owner_idId",
                table: "Pets");

            migrationBuilder.DropIndex(
                name: "IX_Pets_Old_owner_idId",
                table: "Pets");

            migrationBuilder.DropColumn(
                name: "New_owner_idId",
                table: "Pets");

            migrationBuilder.DropColumn(
                name: "Old_owner_idId",
                table: "Pets");

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
