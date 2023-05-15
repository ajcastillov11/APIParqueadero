using APIParqueadero.ApplicationCore.Interfaces;
using APIParqueadero.ApplicationCore.Models;
using APIParqueadero.ApplicationCore.Repository;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics.CodeAnalysis;

namespace APIParqueadero.Infrastructure.Data
{
	public class DataContext : DbContext, IUnitOfWork
	{
		private IVehiculoRepository _vehiculoRepository;
		public DataContext(DbContextOptions<DataContext> options) : base(options)
		{

		}

		public DataContext()
		{
            
        }

        public DbSet<TipoVehiculo> TiposVehiculos { get; set; }
		public DbSet<Vehiculo> Vehiculos { get; set; }
		public DbSet<Factura> Facturas { get; set; }
		public IVehiculoRepository VehiculoRepository
		{
			get
			{
				if (_vehiculoRepository == null)
				{
					_vehiculoRepository = new VehiculoRepository(this);
				}

				return _vehiculoRepository;
			}
		}
	}
}
