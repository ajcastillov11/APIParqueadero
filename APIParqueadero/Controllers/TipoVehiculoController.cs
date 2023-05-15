using APIParqueadero.Api.Interfaces;
using APIParqueadero.Api.Models;
using Microsoft.AspNetCore.Mvc;

namespace APIParqueadero.Api.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class TipoVehiculoController : ControllerBase
	{
		private readonly ITipoVehiculoService _tipoVehiculoService;

		public TipoVehiculoController(ITipoVehiculoService tipoVehiculoService)
		{
			_tipoVehiculoService = tipoVehiculoService;
		}

		// GET: api/TipoVehiculo
		[HttpGet]
		public async Task<ActionResult<IEnumerable<TipoVehiculo>>> GetTiposVehiculos()
		{
			return Ok(await _tipoVehiculoService.GetTiposVehiculos());
		}
	}
}
