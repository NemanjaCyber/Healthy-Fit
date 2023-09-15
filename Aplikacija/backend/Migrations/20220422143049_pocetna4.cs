using Microsoft.EntityFrameworkCore.Migrations;

namespace Aplikacija_swe.Migrations
{
    public partial class pocetna4 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Obrok",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Dan = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TipObroka = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SlikaPutanja = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Opis = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Obrok", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Vezba",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Dan = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PeriodDanaKadaSeVezbaIzvodi = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BrojPonavljanja = table.Column<int>(type: "int", nullable: false),
                    SlikaPutanja = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Opis = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Vezba", x => x.ID);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Obrok");

            migrationBuilder.DropTable(
                name: "Vezba");
        }
    }
}
