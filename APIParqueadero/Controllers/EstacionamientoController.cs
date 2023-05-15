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

        [HttpGet("ListadoVehiculos/{fechaInicial}/{fechaFinal}")]
        public async Task<ActionResult<List<VehiculosDto>>> GetVehiculos(DateTime fechaInicial, DateTime fechaFinal)
        {
            try
            {
                List<VehiculosDto> listaVehiculos = await _estacionamientoService.GetListadoVehiculos(fechaInicial, fechaFinal);
                return Ok(listaVehiculos);
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }

        [HttpPut("Liquidar")]
        public async Task<ActionResult<string>> LiquidarEstacionamiento(LiquidacionDto liquidacionDto)
        {
            try
            {
                if (liquidacionDto is null)
                {
                    return Problem("El request no puede ser vacio.");
                }

                Models.Vehiculo? vehiculo = await _estacionamientoService.VehiculoExistente(liquidacionDto.Placa);
                if (vehiculo == null)
                {
                    return NotFound($"El Vehículo con placas {liquidacionDto.Placa} no se encuentra registrado en este paqueadero");
                }

                return Ok(await _estacionamientoService.LiquidarEstacionamiento(liquidacionDto, vehiculo));
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        [HttpPost("RegistrarIngreso")]
        public async Task<ActionResult<string>> RegistrarIngreso(VehiculoDto vehiculo)
        {
            if (vehiculo is null)
            {
                return Problem("El request no puede ser vacio.");
            }

            return Ok(await _estacionamientoService.RegistrarIngreso(vehiculo));
        }
    }
}
