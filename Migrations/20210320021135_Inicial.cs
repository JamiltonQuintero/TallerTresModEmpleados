using Microsoft.EntityFrameworkCore.Migrations;

namespace TallerTresModEmpleados.Migrations
{
    public partial class Inicial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "EmpleadosPrivTours",
                columns: table => new
                {
                    EmpleadoId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(nullable: true),
                    Apellido = table.Column<string>(nullable: true),
                    Documento = table.Column<string>(nullable: true),
                    Email = table.Column<string>(nullable: true),
                    Celular = table.Column<string>(nullable: true),
                    Contrasena = table.Column<string>(nullable: true),
                    CargoId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EmpleadosPrivTours", x => x.EmpleadoId);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "EmpleadosPrivTours");
        }
    }
}
