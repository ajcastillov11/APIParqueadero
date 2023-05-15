using APIParqueadero.Api.Data;
using APIParqueadero.Api.Interfaces;
using APIParqueadero.Api.Models;
using Microsoft.EntityFrameworkCore;

namespace APIParqueadero.Api.Services
{
	public class TipoVehiculoService : ITipoVehiculoService
	{
		private readonly DataContext _context;

		public TipoVehiculoService(DataContext context)
		{
			_context = context;
		}

		public async Task<IEnumerable<TipoVehiculo>> GetTiposVehiculos()
		{
			//TipoVehiculo tipo = new()
			//{
			//	Nombre = "Carro",
			//	Tarifa = 110

			//};

			//_context.TiposVehiculos.Add(tipo);
			//await _context.SaveChangesAsync();

			return await _context.TiposVehiculos.ToListAsync();
		}
	}
}
