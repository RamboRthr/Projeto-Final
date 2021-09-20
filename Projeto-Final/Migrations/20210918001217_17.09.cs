using Microsoft.EntityFrameworkCore.Migrations;

namespace Projeto_Final.Migrations
{
    public partial class _1709 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Address",
                table: "Users",
                newName: "Street");

            migrationBuilder.AddColumn<string>(
                name: "CEP",
                table: "Users",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "District",
                table: "Users",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "House_number",
                table: "Users",
                type: "text",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CEP",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "District",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "House_number",
                table: "Users");

            migrationBuilder.RenameColumn(
                name: "Street",
                table: "Users",
                newName: "Address");
        }
    }
}
