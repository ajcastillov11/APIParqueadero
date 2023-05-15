using APIParqueadero.ApplicationCore.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APIParqueadero.Infrastructure.Data
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
