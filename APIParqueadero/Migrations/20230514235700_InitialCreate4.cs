using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace APIParqueadero.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate4 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Vehiculo_TiposVehiculos_TipoVehiculoId",
                table: "Vehiculo");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Vehiculo",
                table: "Vehiculo");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Factura",
                table: "Factura");

            migrationBuilder.RenameTable(
                name: "Vehiculo",
                newName: "Vehiculos");

            migrationBuilder.RenameTable(
                name: "Factura",
                newName: "Facturas");

            migrationBuilder.RenameIndex(
                name: "IX_Vehiculo_TipoVehiculoId",
                table: "Vehiculos",
                newName: "IX_Vehiculos_TipoVehiculoId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Vehiculos",
                table: "Vehiculos",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Facturas",
                table: "Facturas",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Vehiculos_TiposVehiculos_TipoVehiculoId",
                table: "Vehiculos",
                column: "TipoVehiculoId",
                principalTable: "TiposVehiculos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Vehiculos_TiposVehiculos_TipoVehiculoId",
                table: "Vehiculos");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Vehiculos",
                table: "Vehiculos");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Facturas",
                table: "Facturas");

            migrationBuilder.RenameTable(
                name: "Vehiculos",
                newName: "Vehiculo");

            migrationBuilder.RenameTable(
                name: "Facturas",
                newName: "Factura");

            migrationBuilder.RenameIndex(
                name: "IX_Vehiculos_TipoVehiculoId",
                table: "Vehiculo",
                newName: "IX_Vehiculo_TipoVehiculoId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Vehiculo",
                table: "Vehiculo",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Factura",
                table: "Factura",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Vehiculo_TiposVehiculos_TipoVehiculoId",
                table: "Vehiculo",
                column: "TipoVehiculoId",
                principalTable: "TiposVehiculos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
