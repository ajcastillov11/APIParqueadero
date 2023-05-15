using APIParqueadero.ApplicationCore.Models;
using Microsoft.EntityFrameworkCore;

namespace APIParqueadero.ApplicationCore.Data
{
	public class DataContext : DbContext
	{
		public DataContext(DbContextOptions<DataContext> options) : base(options)
		{

		}

		public DbSet<TipoVehiculo> TiposVehiculos { get; set; }
		public DbSet<Vehiculo> Vehiculos { get; set; }
		public DbSet<Factura> Facturas { get; set; }
	}
}
