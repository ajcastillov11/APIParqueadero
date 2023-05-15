namespace APIParqueadero.Api.Dto
{
	public class VehiculosDto
	{
		public DateTime FechaIngreso { get; set; }
		public string TipoVehiculo { get; set; } = string.Empty;
		public string Placa { get; internal set; } = string.Empty;
		public DateTime? FechaSalida { get; set; }
		public int? TiempoParqueo { get; set; }
		public double ValorPagado { get; set; }
		public string Estado { get; set; } = string.Empty;
		public string Propietario { get; set; } = string.Empty;
		public string Telefono { get; set; } = string.Empty;
	}
}
