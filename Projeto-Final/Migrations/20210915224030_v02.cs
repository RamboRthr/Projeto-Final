using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace Projeto_Final.Migrations
{
    public partial class v02 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Users",
                table: "Users");

            migrationBuilder.RenameColumn(
                name: "Sobrenome",
                table: "Users",
                newName: "Surname");

            migrationBuilder.RenameColumn(
                name: "Nome",
                table: "Users",
                newName: "Phone");

            migrationBuilder.RenameColumn(
                name: "DataNascimento",
                table: "Users",
                newName: "BirthDate");

            migrationBuilder.AlterColumn<string>(
                name: "CPF",
                table: "Users",
                type: "text",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.AddColumn<int>(
                name: "Id",
                table: "Users",
                type: "integer",
                nullable: false,
                defaultValue: 0)
                .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

            migrationBuilder.AddColumn<string>(
                name: "Address",
                table: "Users",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "Adopted",
                table: "Users",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "Donated",
                table: "Users",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "Users",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Password",
                table: "Users",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "Adopted",
                table: "Pets",
                type: "boolean",
                nullable: false,
                defaultValue: false);

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

            migrationBuilder.AddColumn<DateTime>(
                name: "Publication_date",
                table: "Pets",
                type: "timestamp without time zone",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "Size",
                table: "Pets",
                type: "text",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Users",
                table: "Users",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "Photos",
                columns: table => new
                {
                    Photo_Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Pet_name = table.Column<string>(type: "text", nullable: true),
                    User_Id = table.Column<int>(type: "integer", nullable: false),
                    Publication_date = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    PhotoURL = table.Column<string>(type: "text", nullable: true),
                    PetsId = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Photos", x => x.Photo_Id);
                    table.ForeignKey(
                        name: "FK_Photos_Pets_PetsId",
                        column: x => x.PetsId,
                        principalTable: "Pets",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Photos_PetsId",
                table: "Photos",
                column: "PetsId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Photos");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Users",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "Address",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "Adopted",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "Donated",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "Name",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "Password",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "Adopted",
                table: "Pets");

            migrationBuilder.DropColumn(
                name: "New_owner_id",
                table: "Pets");

            migrationBuilder.DropColumn(
                name: "Old_owner_id",
                table: "Pets");

            migrationBuilder.DropColumn(
                name: "Publication_date",
                table: "Pets");

            migrationBuilder.DropColumn(
                name: "Size",
                table: "Pets");

            migrationBuilder.RenameColumn(
                name: "Surname",
                table: "Users",
                newName: "Sobrenome");

            migrationBuilder.RenameColumn(
                name: "Phone",
                table: "Users",
                newName: "Nome");

            migrationBuilder.RenameColumn(
                name: "BirthDate",
                table: "Users",
                newName: "DataNascimento");

            migrationBuilder.AlterColumn<string>(
                name: "CPF",
                table: "Users",
                type: "text",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "text",
                oldNullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Users",
                table: "Users",
                column: "CPF");
        }
    }
}
