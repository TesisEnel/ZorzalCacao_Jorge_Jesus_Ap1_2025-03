using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ZorzalCacao.Migrations
{
    /// <inheritdoc />
    public partial class RefeAdd : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Referencia",
                table: "ZonasProduccion",
                type: "nvarchar(max)",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Referencia",
                table: "ZonasProduccion");
        }
    }
}
