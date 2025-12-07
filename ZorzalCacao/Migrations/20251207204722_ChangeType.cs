using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ZorzalCacao.Migrations
{
    /// <inheritdoc />
    public partial class ChangeType : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "CertificacionesProducto",
                table: "Recogidas",
                newName: "CertificacionProducto");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "CertificacionProducto",
                table: "Recogidas",
                newName: "CertificacionesProducto");
        }
    }
}
