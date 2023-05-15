using APIParqueadero.Api.Models;

namespace APIParqueadero.Api.Interfaces
{
	public interface ITipoVehiculoService
	{
		Task<IEnumerable<TipoVehiculo>> GetTiposVehiculos();
	}
}
