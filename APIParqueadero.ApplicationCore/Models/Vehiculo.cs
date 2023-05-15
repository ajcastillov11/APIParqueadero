using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace APIParqueadero.ApplicationCore.Models
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
		public long Telefono { get; set; }

		[ForeignKey("TipoVehiculoId")]
		public TipoVehiculo? TipoVehiculo { get; set; }
	}
}
