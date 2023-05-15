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
			return await _context.TiposVehiculos.ToListAsync();
		}
	}
}
