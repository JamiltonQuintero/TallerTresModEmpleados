using Microsoft.EntityFrameworkCore.Migrations;

namespace TallerTresModEmpleados.Migrations
{
    public partial class llaves : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_EmpleadosPrivTours_CargoId",
                table: "EmpleadosPrivTours",
                column: "CargoId");

            migrationBuilder.AddForeignKey(
                name: "FK_EmpleadosPrivTours_CargosPrivTours_CargoId",
                table: "EmpleadosPrivTours",
                column: "CargoId",
                principalTable: "CargosPrivTours",
                principalColumn: "CargoId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_EmpleadosPrivTours_CargosPrivTours_CargoId",
                table: "EmpleadosPrivTours");

            migrationBuilder.DropIndex(
                name: "IX_EmpleadosPrivTours_CargoId",
                table: "EmpleadosPrivTours");
        }
    }
}
