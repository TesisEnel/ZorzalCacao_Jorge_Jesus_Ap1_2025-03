using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ZorzalCacao.Migrations
{
    /// <inheritdoc />
    public partial class EventosClimaticosModificaciones : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "EmpleadoId",
                table: "EventosClimaticos",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateIndex(
                name: "IX_EventosClimaticos_EmpleadoId",
                table: "EventosClimaticos",
                column: "EmpleadoId");

            migrationBuilder.AddForeignKey(
                name: "FK_EventosClimaticos_AspNetUsers_EmpleadoId",
                table: "EventosClimaticos",
                column: "EmpleadoId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_EventosClimaticos_AspNetUsers_EmpleadoId",
                table: "EventosClimaticos");

            migrationBuilder.DropIndex(
                name: "IX_EventosClimaticos_EmpleadoId",
                table: "EventosClimaticos");

            migrationBuilder.DropColumn(
                name: "EmpleadoId",
                table: "EventosClimaticos");
        }
    }
}
