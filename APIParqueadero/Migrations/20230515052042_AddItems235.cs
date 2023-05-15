using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace APIParqueadero.Api.Migrations
{
    /// <inheritdoc />
    public partial class AddItems235 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "FechaSalida",
                table: "Facturas",
                type: "datetime2",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.AddColumn<string>(
                name: "NumeroFacturaSupermercado",
                table: "Facturas",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "RealizoCompraSupermercado",
                table: "Facturas",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "NumeroFacturaSupermercado",
                table: "Facturas");

            migrationBuilder.DropColumn(
                name: "RealizoCompraSupermercado",
                table: "Facturas");

            migrationBuilder.AlterColumn<DateTime>(
                name: "FechaSalida",
                table: "Facturas",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true);
        }
    }
}
