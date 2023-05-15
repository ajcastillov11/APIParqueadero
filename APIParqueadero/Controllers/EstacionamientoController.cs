using APIParqueadero.Api.Dto;
using APIParqueadero.Api.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace APIParqueadero.Api.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class EstacionamientoController : ControllerBase
	{
		private readonly IEstacionamientoService _estacionamientoService;

		public EstacionamientoController(IEstacionamientoService vehiculoService)
		{
			_estacionamientoService = vehiculoService;
		}


		//// GET: api/Vehiculoes/5
		//[HttpGet("{id}")]
		//public async Task<ActionResult<Vehiculo>> GetVehiculo(int id)
		//{
		//	if (_context.Vehiculos == null)
		//	{
		//		return NotFound();
		//	}
		//	var vehiculo = await _context.Vehiculos.FindAsync(id);

		//	if (vehiculo == null)
		//	{
		//		return NotFound();
		//	}

		//	return vehiculo;
		//}

		[HttpPut("Liquidar")]
		public async Task<IActionResult> LiquidarEstacionamiento(LiquidacionDto liquidacionDto)
		{
			try
			{
				Models.Vehiculo? vehiculo = await _estacionamientoService.VehiculoExistente(liquidacionDto.Placa);
				if (vehiculo == null)
				{
					return NotFound($"El vehiculo con placas {liquidacionDto.Placa} no se encuentra registrado en este paqueadero");
				}

				await _estacionamientoService.LiquidarEstacionamiento(liquidacionDto, vehiculo);
			}
			catch (Exception ex)
			{
				throw new Exception(ex.Message);
			}

			return NoContent();
		}

		[HttpPost("RegistrarIngreso")]
		public async Task<ActionResult<string>> PostVehiculo(VehiculoDto vehiculo)
		{
			if (vehiculo is null)
			{
				return Problem("El request no puede ser vacio.");
			}

			await _estacionamientoService.RegistrarIngreso(vehiculo);

			return $"Vehiculo con placas {vehiculo.Placa} registrado correctamente";
		}
	}
}
