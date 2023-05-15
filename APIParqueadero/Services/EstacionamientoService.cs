using APIParqueadero.Api.Data;
using APIParqueadero.Api.Interfaces;
using APIParqueadero.Api.Models;
using Microsoft.EntityFrameworkCore;

namespace APIParqueadero.Api.Services
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
				vehiculoAux = await RegistrarVehiculo(vehiculo);
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
