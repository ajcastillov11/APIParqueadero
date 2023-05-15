using APIParqueadero.Api.Data;
using APIParqueadero.Api.Dto;
using APIParqueadero.Api.Helpers.Extensions;
using APIParqueadero.Api.Interfaces;
using APIParqueadero.Api.Models;
using Microsoft.EntityFrameworkCore;

namespace APIParqueadero.Api.Services
{
	public class EstacionamientoService : IEstacionamientoService
	{
		private readonly DataContext _context;

		public EstacionamientoService(DataContext context)
		{
			_context = context;
		}

		public async Task RegistrarIngreso(VehiculoDto vehiculo)
		{
			try
			{
				if (VehiculoExiste(vehiculo.Placa))
				{
					throw new Exception("Usted tiene una factura pendiente por liquidar");
				}

				await RegistrarVehiculo(vehiculo);
			}
			catch (Exception ex)
			{

				throw new Exception(ex.Message);
			}

		}

		private async Task<Vehiculo> RegistrarVehiculo(VehiculoDto vehiculo)
		{
			int idFactura = await _context.Vehiculos.OrderByDescending(x => x.Id).Select(x => x.Id).FirstOrDefaultAsync();

			idFactura++;
			Vehiculo vehiculoEntidad = new()
			{
				Placa = vehiculo.Placa,
				NombreResponsable = vehiculo.NombreResponsable,
				Telefono = vehiculo.Telefono,
				TipoVehiculoId = vehiculo.TipoVehiculoId,
				Estado = "A",
				FechaIngreso = DateTime.Now,
				ValorPagado = 0,
				FacturaNumero = Extensiones.GenerarNumeroFactura(idFactura.ToString()),
				NumeroFacturaSupermercado = string.Empty,
				RealizoCompraSupermercado = false
			};

			Microsoft.EntityFrameworkCore.ChangeTracking.EntityEntry<Vehiculo> dto = _context.Vehiculos.Add(vehiculoEntidad);
			await _context.SaveChangesAsync();
			return dto.Entity;
		}

		private bool VehiculoExiste(string? placa)
			=> (_context.Vehiculos?.Any(e => e.Placa == placa && e.Estado == "A")).GetValueOrDefault();

	}
}
