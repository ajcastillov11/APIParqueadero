using System.ComponentModel.DataAnnotations;

namespace APIParqueadero.Api.Dto
{
	public class VehiculoDto
	{
		public string Placa { get; set; } = string.Empty;
		public int TipoVehiculoId { get; set; }
		[StringLength(150)]
		public string NombreResponsable { get; set; } = string.Empty;
		public string Telefono { get; set; } = string.Empty;
	}
}
