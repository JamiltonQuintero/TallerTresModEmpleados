using Microsoft.EntityFrameworkCore.Migrations;

namespace TallerTresModEmpleados.Migrations
{
    public partial class SeagregarCargo : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "CambioEstado",
                table: "EmpleadosPrivTours",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CambioEstado",
                table: "EmpleadosPrivTours");
        }
    }
}
