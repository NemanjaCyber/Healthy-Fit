using Microsoft.EntityFrameworkCore.Migrations;

namespace Aplikacija_swe.Migrations
{
    public partial class KomntarIOcena : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Obrok_Plan_ObrokPlanID",
                table: "Obrok");

            migrationBuilder.DropForeignKey(
                name: "FK_Plan_StrucnoLice_PlanStrucnjakID",
                table: "Plan");

            migrationBuilder.DropForeignKey(
                name: "FK_Vezba_Plan_VezbaPlanID",
                table: "Vezba");

            migrationBuilder.DropColumn(
                name: "Komentari",
                table: "StrucnoLice");

            migrationBuilder.RenameColumn(
                name: "ProsecnaOcena",
                table: "StrucnoLice",
                newName: "BrojRacuna");

            migrationBuilder.AlterColumn<int>(
                name: "VezbaPlanID",
                table: "Vezba",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "PlanStrucnjakID",
                table: "Plan",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "ObrokPlanID",
                table: "Obrok",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.CreateTable(
                name: "KomentarIOcena",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Komentar = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Ocena = table.Column<int>(type: "int", nullable: false),
                    OcenaKomentarKorisnikID = table.Column<int>(type: "int", nullable: false),
                    OcenaKomentarStrucnjakID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_KomentarIOcena", x => x.ID);
                    table.ForeignKey(
                        name: "FK_KomentarIOcena_Korisnik_OcenaKomentarKorisnikID",
                        column: x => x.OcenaKomentarKorisnikID,
                        principalTable: "Korisnik",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_KomentarIOcena_StrucnoLice_OcenaKomentarStrucnjakID",
                        column: x => x.OcenaKomentarStrucnjakID,
                        principalTable: "StrucnoLice",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_KomentarIOcena_OcenaKomentarKorisnikID",
                table: "KomentarIOcena",
                column: "OcenaKomentarKorisnikID");

            migrationBuilder.CreateIndex(
                name: "IX_KomentarIOcena_OcenaKomentarStrucnjakID",
                table: "KomentarIOcena",
                column: "OcenaKomentarStrucnjakID");

            migrationBuilder.AddForeignKey(
                name: "FK_Obrok_Plan_ObrokPlanID",
                table: "Obrok",
                column: "ObrokPlanID",
                principalTable: "Plan",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Plan_StrucnoLice_PlanStrucnjakID",
                table: "Plan",
                column: "PlanStrucnjakID",
                principalTable: "StrucnoLice",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Vezba_Plan_VezbaPlanID",
                table: "Vezba",
                column: "VezbaPlanID",
                principalTable: "Plan",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Obrok_Plan_ObrokPlanID",
                table: "Obrok");

            migrationBuilder.DropForeignKey(
                name: "FK_Plan_StrucnoLice_PlanStrucnjakID",
                table: "Plan");

            migrationBuilder.DropForeignKey(
                name: "FK_Vezba_Plan_VezbaPlanID",
                table: "Vezba");

            migrationBuilder.DropTable(
                name: "KomentarIOcena");

            migrationBuilder.RenameColumn(
                name: "BrojRacuna",
                table: "StrucnoLice",
                newName: "ProsecnaOcena");

            migrationBuilder.AlterColumn<int>(
                name: "VezbaPlanID",
                table: "Vezba",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<string>(
                name: "Komentari",
                table: "StrucnoLice",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "PlanStrucnjakID",
                table: "Plan",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "ObrokPlanID",
                table: "Obrok",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_Obrok_Plan_ObrokPlanID",
                table: "Obrok",
                column: "ObrokPlanID",
                principalTable: "Plan",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Plan_StrucnoLice_PlanStrucnjakID",
                table: "Plan",
                column: "PlanStrucnjakID",
                principalTable: "StrucnoLice",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Vezba_Plan_VezbaPlanID",
                table: "Vezba",
                column: "VezbaPlanID",
                principalTable: "Plan",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
