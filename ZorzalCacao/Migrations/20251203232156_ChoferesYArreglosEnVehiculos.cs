using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ZorzalCacao.Migrations
{
    /// <inheritdoc />
    public partial class ChoferesYArreglosEnVehiculos : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Choferes",
                columns: table => new
                {
                    ChoferId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Apellido = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Cedula = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Telefono = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Licencia = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Choferes", x => x.ChoferId);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Vehiculos_ChoferId",
                table: "Vehiculos",
                column: "ChoferId");

            migrationBuilder.AddForeignKey(
                name: "FK_Vehiculos_Choferes_ChoferId",
                table: "Vehiculos",
                column: "ChoferId",
                principalTable: "Choferes",
                principalColumn: "ChoferId",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Vehiculos_Choferes_ChoferId",
                table: "Vehiculos");

            migrationBuilder.DropTable(
                name: "Choferes");

            migrationBuilder.DropIndex(
                name: "IX_Vehiculos_ChoferId",
                table: "Vehiculos");
        }
    }
}
