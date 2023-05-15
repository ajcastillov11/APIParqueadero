using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace APIParqueadero.Api.Migrations
{
    /// <inheritdoc />
    public partial class AddItems344436 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Facturas_Vehiculos_VehiculoId",
                table: "Facturas");

            migrationBuilder.DropForeignKey(
                name: "FK_Vehiculos_TiposVehiculos_TipoVehiculoId",
                table: "Vehiculos");

            migrationBuilder.DropIndex(
                name: "IX_Vehiculos_TipoVehiculoId",
                table: "Vehiculos");

            migrationBuilder.DropIndex(
                name: "IX_Facturas_VehiculoId",
                table: "Facturas");

            migrationBuilder.AddColumn<string>(
                name: "NumeroFactura",
                table: "Facturas",
                type: "nvarchar(max)",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "NumeroFactura",
                table: "Facturas");

            migrationBuilder.CreateIndex(
                name: "IX_Vehiculos_TipoVehiculoId",
                table: "Vehiculos",
                column: "TipoVehiculoId");

            migrationBuilder.CreateIndex(
                name: "IX_Facturas_VehiculoId",
                table: "Facturas",
                column: "VehiculoId");

            migrationBuilder.AddForeignKey(
                name: "FK_Facturas_Vehiculos_VehiculoId",
                table: "Facturas",
                column: "VehiculoId",
                principalTable: "Vehiculos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Vehiculos_TiposVehiculos_TipoVehiculoId",
                table: "Vehiculos",
                column: "TipoVehiculoId",
                principalTable: "TiposVehiculos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
