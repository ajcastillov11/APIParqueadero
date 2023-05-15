using APIParqueadero.Api.Dto;

namespace APIParqueadero.Api.Interfaces
{
	public interface IEstacionamientoService
	{
		Task RegistrarIngreso(VehiculoDto vehiculo);
	}
}
