using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace APIParqueadero.Api.Migrations
{
    /// <inheritdoc />
    public partial class AddItems005 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Facturas");

            migrationBuilder.AddColumn<string>(
                name: "Estado",
                table: "Vehiculos",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "FacturaNumero",
                table: "Vehiculos",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "FechaIngreso",
                table: "Vehiculos",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "FechaSalida",
                table: "Vehiculos",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "NumeroFacturaSupermercado",
                table: "Vehiculos",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "RealizoCompraSupermercado",
                table: "Vehiculos",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<decimal>(
                name: "ValorPagado",
                table: "Vehiculos",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Estado",
                table: "Vehiculos");

            migrationBuilder.DropColumn(
                name: "FacturaNumero",
                table: "Vehiculos");

            migrationBuilder.DropColumn(
                name: "FechaIngreso",
                table: "Vehiculos");

            migrationBuilder.DropColumn(
                name: "FechaSalida",
                table: "Vehiculos");

            migrationBuilder.DropColumn(
                name: "NumeroFacturaSupermercado",
                table: "Vehiculos");

            migrationBuilder.DropColumn(
                name: "RealizoCompraSupermercado",
                table: "Vehiculos");

            migrationBuilder.DropColumn(
                name: "ValorPagado",
                table: "Vehiculos");

            migrationBuilder.CreateTable(
                name: "Facturas",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Estado = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FacturaNumero = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FechaIngreso = table.Column<DateTime>(type: "datetime2", nullable: false),
                    FechaSalida = table.Column<DateTime>(type: "datetime2", nullable: true),
                    NumeroFacturaSupermercado = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    RealizoCompraSupermercado = table.Column<bool>(type: "bit", nullable: false),
                    ValorPagado = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    VehiculoId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Facturas", x => x.Id);
                });
        }
    }
}
