using Microsoft.EntityFrameworkCore.Migrations;

namespace Aplikacija_swe.Migrations
{
    public partial class Autorizacija : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Autorizacija",
                table: "StrucnoLice",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Autorizacija",
                table: "Korisnik",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Autorizacija",
                table: "Admin",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Autorizacija",
                table: "StrucnoLice");

            migrationBuilder.DropColumn(
                name: "Autorizacija",
                table: "Korisnik");

            migrationBuilder.DropColumn(
                name: "Autorizacija",
                table: "Admin");
        }
    }
}
