using Microsoft.EntityFrameworkCore.Migrations;

namespace Aplikacija_swe.Migrations
{
    public partial class inicijalna : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Sajt",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Naziv = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UsloviIPravilaKoriscenja = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sajt", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Admin",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    KorisnickoIme = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Sifra = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Ime = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Prezime = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    AdminSajtID = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Admin", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Admin_Sajt_AdminSajtID",
                        column: x => x.AdminSajtID,
                        principalTable: "Sajt",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Korisnik",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    KorisnickoIme = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Sifra = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Ime = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Prezime = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    DatumRodjenja = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Pol = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    KolicinaNovca = table.Column<int>(type: "int", nullable: false),
                    Cet = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    KorisnikSajtID = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Korisnik", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Korisnik_Sajt_KorisnikSajtID",
                        column: x => x.KorisnikSajtID,
                        principalTable: "Sajt",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "StrucnoLice",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    KorisnickoIme = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Sifra = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Ime = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Prezime = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    DatumRodjenja = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Pol = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    OblastStruke = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Obrazovanje = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    OdobrenjeAdmina = table.Column<bool>(type: "bit", nullable: false),
                    ProsecnaOcena = table.Column<int>(type: "int", nullable: false),
                    KolicinaNovca = table.Column<int>(type: "int", nullable: false),
                    Komentari = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Cet = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    StrucnjakSajtID = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StrucnoLice", x => x.ID);
                    table.ForeignKey(
                        name: "FK_StrucnoLice_Sajt_StrucnjakSajtID",
                        column: x => x.StrucnjakSajtID,
                        principalTable: "Sajt",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Plan",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NazivPlana = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Oblast = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Cena = table.Column<int>(type: "int", nullable: false),
                    PlanStrucnjakID = table.Column<int>(type: "int", nullable: true),
                    SajtID = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Plan", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Plan_Sajt_SajtID",
                        column: x => x.SajtID,
                        principalTable: "Sajt",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Plan_StrucnoLice_PlanStrucnjakID",
                        column: x => x.PlanStrucnjakID,
                        principalTable: "StrucnoLice",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "KorisnikPlan",
                columns: table => new
                {
                    KorisniciPlanoviID = table.Column<int>(type: "int", nullable: false),
                    PlanoviKorisniciID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_KorisnikPlan", x => new { x.KorisniciPlanoviID, x.PlanoviKorisniciID });
                    table.ForeignKey(
                        name: "FK_KorisnikPlan_Korisnik_PlanoviKorisniciID",
                        column: x => x.PlanoviKorisniciID,
                        principalTable: "Korisnik",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_KorisnikPlan_Plan_KorisniciPlanoviID",
                        column: x => x.KorisniciPlanoviID,
                        principalTable: "Plan",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Admin_AdminSajtID",
                table: "Admin",
                column: "AdminSajtID");

            migrationBuilder.CreateIndex(
                name: "IX_Korisnik_KorisnikSajtID",
                table: "Korisnik",
                column: "KorisnikSajtID");

            migrationBuilder.CreateIndex(
                name: "IX_KorisnikPlan_PlanoviKorisniciID",
                table: "KorisnikPlan",
                column: "PlanoviKorisniciID");

            migrationBuilder.CreateIndex(
                name: "IX_Plan_PlanStrucnjakID",
                table: "Plan",
                column: "PlanStrucnjakID");

            migrationBuilder.CreateIndex(
                name: "IX_Plan_SajtID",
                table: "Plan",
                column: "SajtID");

            migrationBuilder.CreateIndex(
                name: "IX_StrucnoLice_StrucnjakSajtID",
                table: "StrucnoLice",
                column: "StrucnjakSajtID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Admin");

            migrationBuilder.DropTable(
                name: "KorisnikPlan");

            migrationBuilder.DropTable(
                name: "Korisnik");

            migrationBuilder.DropTable(
                name: "Plan");

            migrationBuilder.DropTable(
                name: "StrucnoLice");

            migrationBuilder.DropTable(
                name: "Sajt");
        }
    }
}
