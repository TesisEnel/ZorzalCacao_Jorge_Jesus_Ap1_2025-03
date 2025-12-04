using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ZorzalCacao.Migrations
{
    /// <inheritdoc />
    public partial class CreandoSaco : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Descripcion",
                table: "Sacos",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.InsertData(
                table: "Sacos",
                columns: new[] { "SacoId", "CantidadPesada", "Descripcion" },
                values: new object[] { 1, 0.0, "Saco estándar" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Sacos",
                keyColumn: "SacoId",
                keyValue: 1);

            migrationBuilder.DropColumn(
                name: "Descripcion",
                table: "Sacos");
        }
    }
}
