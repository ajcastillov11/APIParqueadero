using APIParqueadero.Api.Models;

namespace APIParqueadero.Api.Interfaces
{
	public interface IEstacionamientoService
	{
		Task RegistrarIngreso(Vehiculo vehiculo);
	}
}
