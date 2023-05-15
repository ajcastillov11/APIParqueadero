using System.ComponentModel.DataAnnotations;

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
		public decimal ValorPagado { get; set; }
		public string Estado { get; set; } = string.Empty;
		public bool RealizoCompraSupermercado { get; set; }
		public string NumeroFacturaSupermercado { get; set; } = string.Empty;
	}
}
