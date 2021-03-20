using Microsoft.EntityFrameworkCore.Migrations;

namespace TallerTresModEmpleados.Migrations
{
    public partial class Cargo : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CargosPrivTours",
                columns: table => new
                {
                    CargoId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(nullable: true),
                    Descripcion = table.Column<string>(nullable: true),
                    InternoExterno = table.Column<string>(nullable: true),
                    CambioEstado = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CargosPrivTours", x => x.CargoId);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CargosPrivTours");
        }
    }
}
