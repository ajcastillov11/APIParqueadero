using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace APIParqueadero.Api.Models
{
	public class Vehiculo
	{
		[Key]
		public int Id { get; set; }
		[StringLength(20)]
		public string Placa { get; set; } = string.Empty;
		public int TipoVehiculoId { get; set; }
		[StringLength(150)]
		public string NombreResponsable { get; set; } = string.Empty;
		public string Telefono { get; set; } = string.Empty;
		public string FacturaNumero { get; set; } = string.Empty;
		public DateTime FechaIngreso { get; set; }
		public DateTime? FechaSalida { get; set; }
		public double ValorPagado { get; set; }
		public string Estado { get; set; } = string.Empty;
		public string NumeroFacturaSupermercado { get; set; } = string.Empty;

		[ForeignKey("TipoVehiculoId")]
		public TipoVehiculo TipoVehiculo { get; set; } = null!;
		public int? TiempoParqueo { get; set; }
	}
}
