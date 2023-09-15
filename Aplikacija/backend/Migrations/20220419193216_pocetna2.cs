using Microsoft.EntityFrameworkCore.Migrations;

namespace Aplikacija_swe.Migrations
{
    public partial class pocetna2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Slika",
                table: "StrucnoLice",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Slika",
                table: "Korisnik",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Slika",
                table: "StrucnoLice");

            migrationBuilder.DropColumn(
                name: "Slika",
                table: "Korisnik");
        }
    }
}
