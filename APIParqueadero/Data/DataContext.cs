using APIParqueadero.Api.Models;
using Microsoft.EntityFrameworkCore;

namespace APIParqueadero.Api.Data
{
	public class DataContext : DbContext
	{
		public DataContext(DbContextOptions<DataContext> options) : base(options)
		{

		}

		public DbSet<TipoVehiculo> TiposVehiculos { get; set; }
		public DbSet<Vehiculo> Vehiculos { get; set; }
	}
}
