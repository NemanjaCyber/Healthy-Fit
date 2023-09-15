using Microsoft.EntityFrameworkCore.Migrations;

namespace Aplikacija_swe.Migrations
{
    public partial class pocetna5 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "VezbaPlanID",
                table: "Vezba",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ObrokPlanID",
                table: "Obrok",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Vezba_VezbaPlanID",
                table: "Vezba",
                column: "VezbaPlanID");

            migrationBuilder.CreateIndex(
                name: "IX_Obrok_ObrokPlanID",
                table: "Obrok",
                column: "ObrokPlanID");

            migrationBuilder.AddForeignKey(
                name: "FK_Obrok_Plan_ObrokPlanID",
                table: "Obrok",
                column: "ObrokPlanID",
                principalTable: "Plan",
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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Obrok_Plan_ObrokPlanID",
                table: "Obrok");

            migrationBuilder.DropForeignKey(
                name: "FK_Vezba_Plan_VezbaPlanID",
                table: "Vezba");

            migrationBuilder.DropIndex(
                name: "IX_Vezba_VezbaPlanID",
                table: "Vezba");

            migrationBuilder.DropIndex(
                name: "IX_Obrok_ObrokPlanID",
                table: "Obrok");

            migrationBuilder.DropColumn(
                name: "VezbaPlanID",
                table: "Vezba");

            migrationBuilder.DropColumn(
                name: "ObrokPlanID",
                table: "Obrok");
        }
    }
}
