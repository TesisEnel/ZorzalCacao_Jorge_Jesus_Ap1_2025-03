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
            migrationBuilder.AlterColumn<double>(
                name: "Cantidad",
                table: "FermentacionesDetalles",
                type: "float",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "Cantidad",
                table: "FermentacionesDetalles",
                type: "int",
                nullable: false,
                oldClrType: typeof(double),
                oldType: "float");
        }
    }
}
