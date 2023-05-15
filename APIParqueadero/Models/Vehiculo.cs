using System.ComponentModel.DataAnnotations;

namespace APIParqueadero.Api.Models
{
	public class Vehiculo
	{
		[Key]
		public int Id { get; set; }
		[StringLength(20)]
		public string? Placa { get; set; }
		public int TipoVehiculoId { get; set; }
		[StringLength(150)]
		public string? NombreResponsable { get; set; }
		public string? Telefono { get; set; }
		public string? FacturaNumero { get; set; }
		public DateTime FechaIngreso { get; set; }
		public DateTime? FechaSalida { get; set; }
		public decimal ValorPagado { get; set; }
		public string? Estado { get; set; }
		public bool RealizoCompraSupermercado { get; set; }
		public string? NumeroFacturaSupermercado { get; set; }
	}
}
