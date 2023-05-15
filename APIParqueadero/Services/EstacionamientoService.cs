using APIParqueadero.Api.Data;
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

		public async Task RegistrarIngreso(Vehiculo vehiculo)
		{
			try
			{
				Vehiculo? vehiculoAux = VehiculoExiste(vehiculo.Placa)
					? await _context.Vehiculos.FirstOrDefaultAsync(x => !string.IsNullOrEmpty(x.Placa) && x.Placa.Equals(vehiculo.Placa))
					: await RegistrarVehiculo(vehiculo);

				await Crearfactura(vehiculoAux);
			}
			catch (Exception ex)
			{

				throw;
			}

		}

		private async Task Crearfactura(Vehiculo? vehiculoAux)
		{
			Factura factura = new()
			{
				Estado = "A",
				FechaIngreso = DateTime.Now,
				ValorPagado = 0,
				VehiculoId = vehiculoAux.Id,
			};

			_context.Facturas.Add(factura);

			await _context.SaveChangesAsync();

		}

		private async Task<Vehiculo> RegistrarVehiculo(Vehiculo vehiculo)
		{
			Microsoft.EntityFrameworkCore.ChangeTracking.EntityEntry<Vehiculo> dto = _context.Vehiculos.Add(vehiculo);
			await _context.SaveChangesAsync();
			return dto.Entity;
		}

		private bool VehiculoExiste(string? placa)
			=> (_context.Vehiculos?.Any(e => e.Placa == placa)).GetValueOrDefault();

	}
}
