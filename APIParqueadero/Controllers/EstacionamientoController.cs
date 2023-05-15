using APIParqueadero.Api.Interfaces;
using APIParqueadero.Api.Models;
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

		//// GET: api/Vehiculoes
		//[HttpGet]
		//public async Task<ActionResult<IEnumerable<Vehiculo>>> GetVehiculos()
		//{
		//	if (_context.Vehiculos == null)
		//	{
		//		return NotFound();
		//	}
		//	return await _context.Vehiculos.ToListAsync();
		//}

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

		//// PUT: api/Vehiculoes/5
		//// To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
		//[HttpPut("{id}")]
		//public async Task<IActionResult> PutVehiculo(int id, Vehiculo vehiculo)
		//{
		//	if (id != vehiculo.Id)
		//	{
		//		return BadRequest();
		//	}

		//	_context.Entry(vehiculo).State = EntityState.Modified;

		//	try
		//	{
		//		await _context.SaveChangesAsync();
		//	}
		//	catch (DbUpdateConcurrencyException)
		//	{
		//		if (!VehiculoExists(id))
		//		{
		//			return NotFound();
		//		}
		//		else
		//		{
		//			throw;
		//		}
		//	}

		//	return NoContent();
		//}

		[HttpPost("RegistrarIngreso")]
		public async Task<ActionResult<string>> PostVehiculo(Vehiculo vehiculo)
		{
			if (vehiculo is null)
			{
				return Problem("El request no puede ser vacio.");
			}

			await _estacionamientoService.RegistrarIngreso(vehiculo);

			return $"Vehiculo con placas {vehiculo.Placa} registrado correctamente";
		}

		//// DELETE: api/Vehiculoes/5
		//[HttpDelete("{id}")]
		//public async Task<IActionResult> DeleteVehiculo(int id)
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

		//	_context.Vehiculos.Remove(vehiculo);
		//	await _context.SaveChangesAsync();
		//	return NoContent();
		//}


	}
}
