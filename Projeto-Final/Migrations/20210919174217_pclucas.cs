using Microsoft.EntityFrameworkCore.Migrations;

namespace Projeto_Final.Migrations
{
    public partial class pclucas : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Address",
                table: "Users",
                newName: "Street");

            migrationBuilder.RenameColumn(
                name: "Age",
                table: "Pets",
                newName: "Age_years");

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

            migrationBuilder.AddColumn<int>(
                name: "Age_months",
                table: "Pets",
                type: "integer",
                nullable: false,
                defaultValue: 0);
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

            migrationBuilder.DropColumn(
                name: "Age_months",
                table: "Pets");

            migrationBuilder.RenameColumn(
                name: "Street",
                table: "Users",
                newName: "Address");

            migrationBuilder.RenameColumn(
                name: "Age_years",
                table: "Pets",
                newName: "Age");
        }
    }
}
