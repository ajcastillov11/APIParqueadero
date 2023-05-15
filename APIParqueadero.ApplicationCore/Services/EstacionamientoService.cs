using APIParqueadero.ApplicationCore.Data;
using APIParqueadero.ApplicationCore.Interfaces;
using APIParqueadero.ApplicationCore.Models;
using Microsoft.EntityFrameworkCore;

namespace APIParqueadero.ApplicationCore.Services
{
	public class EstacionamientoService : IEstacionamientoService
	{
		private DataContext _context;

		public EstacionamientoService(DataContext context)
		{
			_context = context;
		}

		public async Task RegistrarIngreso(Vehiculo vehiculo)
		{
			Vehiculo? vehiculoAux;

			if (VehiculoExiste(vehiculo.Placa))
			{
				vehiculoAux = await _context.Vehiculos.FirstOrDefaultAsync(x => !string.IsNullOrEmpty(x.Placa) && x.Placa.Equals(vehiculo.Placa));
			}
			else
			{
				await RegistrarVehiculo(vehiculo);
			}
		}

		private async Task<Vehiculo> RegistrarVehiculo(Vehiculo vehiculo)
		{
			var dto = _context.Vehiculos.Add(vehiculo);
			await _context.SaveChangesAsync();
			return dto.Entity;
		}

		private bool VehiculoExiste(string? placa)
			=> (_context.Vehiculos?.Any(e => e.Placa == placa)).GetValueOrDefault();

	}
}
