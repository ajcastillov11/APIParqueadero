using APIParqueadero.ApplicationCore.Models;

namespace APIParqueadero.ApplicationCore.Interfaces
{
	public interface IEstacionamientoService
	{
		Task RegistrarIngreso(Vehiculo vehiculo);
	}
}
