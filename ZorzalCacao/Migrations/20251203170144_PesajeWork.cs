using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ZorzalCacao.Migrations
{
    /// <inheritdoc />
    public partial class PesajeWork : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "EmpleadoId",
                table: "Pesajes",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateIndex(
                name: "IX_Pesajes_EmpleadoId",
                table: "Pesajes",
                column: "EmpleadoId");

            migrationBuilder.AddForeignKey(
                name: "FK_Pesajes_AspNetUsers_EmpleadoId",
                table: "Pesajes",
                column: "EmpleadoId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Pesajes_AspNetUsers_EmpleadoId",
                table: "Pesajes");

            migrationBuilder.DropIndex(
                name: "IX_Pesajes_EmpleadoId",
                table: "Pesajes");

            migrationBuilder.DropColumn(
                name: "EmpleadoId",
                table: "Pesajes");
        }
    }
}
