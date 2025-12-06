using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ZorzalCacao.Migrations
{
    /// <inheritdoc />
    public partial class Produccion : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ZonasProduccion",
                columns: table => new
                {
                    ZonaId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Provincia = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Distancia = table.Column<double>(type: "float", nullable: false),
                    ProductorId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ZonasProduccion", x => x.ZonaId);
                    table.ForeignKey(
                        name: "FK_ZonasProduccion_AspNetUsers_ProductorId",
                        column: x => x.ProductorId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ZonasProduccion_ProductorId",
                table: "ZonasProduccion",
                column: "ProductorId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ZonasProduccion");
        }
    }
}
