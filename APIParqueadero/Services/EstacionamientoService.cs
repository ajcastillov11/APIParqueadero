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

		public async Task RegistrarIngreso(VehiculoDto vehiculo)
		{
			try
			{
				Vehiculo? vehiculoExistente = await VehiculoExistente(vehiculo.Placa);
				if (vehiculoExistente != null)
				{
					throw new Exception("Usted tiene una factura pendiente por liquidar.");
				}

				_ = await RegistrarVehiculo(vehiculo);
			}
			catch (Exception ex)
			{

				throw new Exception(ex.Message);
			}

		}

		private async Task<Vehiculo> RegistrarVehiculo(VehiculoDto vehiculo)
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

		public async Task<Vehiculo?> VehiculoExistente(string placa)
		{
			return await _context.Vehiculos.FirstOrDefaultAsync(e => e.Placa == placa && e.FechaSalida == null);
		}

		public async Task LiquidarEstacionamiento(LiquidacionDto liquidacionDto, Vehiculo vehiculo)
		{
			int minutos = DateTime.Now.Subtract(vehiculo.FechaIngreso).Minutes;

			TipoVehiculo? tipoVehiculo = await _context.TiposVehiculos.FirstOrDefaultAsync(x => x.Id == vehiculo.TipoVehiculoId);

			double? valorPagar = tipoVehiculo?.Tarifa * minutos;


			if (!string.IsNullOrEmpty(liquidacionDto.FacturaCompraSuperMercado))
			{
				valorPagar *= 0.30;
			}
		}
	}
}
