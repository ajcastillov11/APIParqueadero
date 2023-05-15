using APIParqueadero.Api.Data;
using APIParqueadero.Api.Dto;
using APIParqueadero.Api.Helpers.Extensions;
using APIParqueadero.Api.Interfaces;
using APIParqueadero.Api.Models;
using Microsoft.EntityFrameworkCore;

namespace APIParqueadero.Api.Services
{
	public class EstacionamientoService : IEstacionamientoService
	{
		private readonly DataContext _context;

		public EstacionamientoService(DataContext context)
		{
			_context = context;
		}

		public async Task<string> RegistrarIngreso(VehiculoDto vehiculo)
		{
			try
			{
				Vehiculo? vehiculoExistente = await VehiculoExistente(vehiculo.Placa);
				if (vehiculoExistente != null)
				{
					throw new Exception("Usted tiene una factura pendiente por liquidar.");
				}

				_ = await RegistrarVehiculo(vehiculo);

				return $"Vehículo con placas {vehiculo.Placa} registrado correctamente";
			}
			catch (Exception ex)
			{

				throw new Exception(ex.Message);
			}

		}

		private async Task<Vehiculo> RegistrarVehiculo(VehiculoDto vehiculo)
		{
			try
			{
				int idFactura = await _context.Vehiculos.OrderByDescending(x => x.Id).Select(x => x.Id).FirstOrDefaultAsync();

				idFactura++;
				Vehiculo vehiculoEntidad = new()
				{
					Placa = vehiculo.Placa,
					NombreResponsable = vehiculo.NombreResponsable,
					Telefono = vehiculo.Telefono,
					TipoVehiculoId = vehiculo.TipoVehiculoId,
					Estado = "A",
					FechaIngreso = DateTime.Now,
					ValorPagado = 0,
					FacturaNumero = Extensiones.GenerarNumeroFactura(idFactura.ToString()),
					NumeroFacturaSupermercado = string.Empty,
				};

				Microsoft.EntityFrameworkCore.ChangeTracking.EntityEntry<Vehiculo> dto = _context.Vehiculos.Add(vehiculoEntidad);
				_ = await _context.SaveChangesAsync();
				return dto.Entity;
			}
			catch (Exception ex)
			{

				throw new Exception(ex.Message);
			}
		}

		public async Task<Vehiculo?> VehiculoExistente(string placa)
		{
			return await _context.Vehiculos.FirstOrDefaultAsync(e => e.Placa == placa && e.FechaSalida == null);
		}

		public async Task<string> LiquidarEstacionamiento(LiquidacionDto liquidacionDto, Vehiculo vehiculo)
		{
			try
			{
				int minutos = DateTime.Now.Subtract(vehiculo.FechaIngreso).Minutes;

				TipoVehiculo? tipoVehiculo = await _context.TiposVehiculos.FirstOrDefaultAsync(x => x.Id == vehiculo.TipoVehiculoId);

				double? valorPagar = tipoVehiculo?.Tarifa * minutos;


				if (!string.IsNullOrEmpty(liquidacionDto.FacturaCompraSuperMercado))
				{
					valorPagar *= 0.30;
				}

				vehiculo.NumeroFacturaSupermercado = liquidacionDto.FacturaCompraSuperMercado;
				vehiculo.ValorPagado = valorPagar.Value;
				vehiculo.FechaSalida = DateTime.Now;
				vehiculo.Estado = "L";
				vehiculo.TiempoParqueo = minutos;
				_ = _context.Vehiculos.Update(vehiculo);

				_ = await _context.SaveChangesAsync();

				return $"Vehículo con placas {liquidacionDto.Placa} liquidado correctamente, valor a pagar ${valorPagar.Value}";
			}
			catch (Exception ex)
			{

				throw new Exception(ex.Message);
			}
		}

		public async Task<List<VehiculosDto>> GetListadoVehiculos(DateTime fechaInicial, DateTime fechaFinal)
		{
			try
			{
				List<VehiculosDto> vechiculos = await (from _vehiculos in _context.Vehiculos.Include(tv => tv.TipoVehiculo)
													   select new VehiculosDto()
													   {
														   TipoVehiculo = _vehiculos.TipoVehiculo.Nombre,
														   FechaIngreso = _vehiculos.FechaIngreso,
														   Placa = _vehiculos.Placa,
														   FechaSalida = _vehiculos.FechaSalida,
														   TiempoParqueo = _vehiculos.FechaSalida.HasValue ? _vehiculos.FechaSalida.Value.Subtract(_vehiculos.FechaIngreso).Minutes : DateTime.Now.Subtract(_vehiculos.FechaIngreso).Minutes,
														   ValorPagado = _vehiculos.ValorPagado,
														   Estado = _vehiculos.Estado,
														   Propietario = _vehiculos.NombreResponsable,
														   Telefono = _vehiculos.Telefono,
													   })
														   .OrderByDescending(d => d.FechaIngreso)
														   .ToListAsync();

				return vechiculos;
			}
			catch (Exception ex) { throw new Exception(ex.Message); }
		}
	}
}
