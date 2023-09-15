using Microsoft.EntityFrameworkCore.Migrations;

namespace Aplikacija_swe.Migrations
{
    public partial class modelPlanaIzmena2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "IdStrucnogLice",
                table: "Plan",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IdStrucnogLice",
                table: "Plan");
        }
    }
}
