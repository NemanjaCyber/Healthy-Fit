using Microsoft.EntityFrameworkCore.Migrations;

namespace Aplikacija_swe.Migrations
{
    public partial class Poruka : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Poruke",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PorukaSadrzaj = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PorukaKorisnikID = table.Column<int>(type: "int", nullable: false),
                    PorukaStrucnjakID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Poruke", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Poruke_Korisnik_PorukaKorisnikID",
                        column: x => x.PorukaKorisnikID,
                        principalTable: "Korisnik",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Poruke_StrucnoLice_PorukaStrucnjakID",
                        column: x => x.PorukaStrucnjakID,
                        principalTable: "StrucnoLice",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Poruke_PorukaKorisnikID",
                table: "Poruke",
                column: "PorukaKorisnikID");

            migrationBuilder.CreateIndex(
                name: "IX_Poruke_PorukaStrucnjakID",
                table: "Poruke",
                column: "PorukaStrucnjakID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Poruke");
        }
    }
}
