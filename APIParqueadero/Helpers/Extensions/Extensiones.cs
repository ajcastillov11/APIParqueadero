using System.ComponentModel.DataAnnotations;

namespace APIParqueadero.Api.Helpers.Extensions
{
	public static class Extensiones
	{
		public static string GenerarNumeroFactura(string codigo)
		{
			try
			{
				return string.Format("{0:D7}", Int64.Parse(codigo));
			}
			catch (Exception)
			{
				throw new ValidationException("Error de Conversion");
			}
		}

		public static string DateTimeToUnixTimestamp(DateTime dateTime)
		{
			string TimeToUtc = (TimeZoneInfo.ConvertTimeToUtc(dateTime) -
				   new DateTime(1970, 1, 1, 0, 0, 0, 0, System.DateTimeKind.Utc)).TotalSeconds.ToString();

			return TimeToUtc.Replace(",", string.Empty).Replace(".", string.Empty);
		}
	}
}
