using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace APIParqueadero.Api.Models
{
	public class Factura
	{
		[Key]
		public int Id { get; set; }
		public DateTime FechaIngreso { get; set; }
		public DateTime? FechaSalida { get; set; }
		public decimal ValorPagado { get; set; }
		[StringLength(3)]
		public string? Estado { get; set; }
		public int VehiculoId { get; set; }

		public bool RealizoCompraSupermercado { get; set; }
		public string? NumeroFacturaSupermercado { get; set; }
		[ForeignKey("VehiculoId")]
		public Vehiculo? Vehiculo { get; set; }
	}
}
