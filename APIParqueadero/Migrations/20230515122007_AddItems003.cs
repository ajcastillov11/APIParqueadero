using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace APIParqueadero.Api.Migrations
{
    /// <inheritdoc />
    public partial class AddItems003 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "NumeroFactura",
                table: "Facturas",
                newName: "FacturaNumero");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "FacturaNumero",
                table: "Facturas",
                newName: "NumeroFactura");
        }
    }
}
