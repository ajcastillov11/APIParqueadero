using APIParqueadero.Api.Dto;
using APIParqueadero.Api.Models;

namespace APIParqueadero.Api.Interfaces
{
	public interface IEstacionamientoService
	{
		Task LiquidarEstacionamiento(LiquidacionDto liquidacionDto, Vehiculo vehiculo);
		Task RegistrarIngreso(VehiculoDto vehiculo);
		Task<Vehiculo?> VehiculoExistente(string placa);
	}
}
