using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SistemaPlacas.Migrations
{
    /// <inheritdoc />
    public partial class CorrecaoStatus : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Status",
                keyColumn: "Id",
                keyValue: 1,
                column: "Nome",
                value: "Imprimir OS");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Status",
                keyColumn: "Id",
                keyValue: 1,
                column: "Nome",
                value: "Imprimir Os");
        }
    }
}
