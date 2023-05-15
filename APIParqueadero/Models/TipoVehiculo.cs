using System.ComponentModel.DataAnnotations;

namespace APIParqueadero.Api.Models
{
    public class TipoVehiculo
    {
        [Key]
        public int Id { get; set; }
        [StringLength(255)]
        [Required]
        [MinLength(3)]
        public string? Nombre { get; set; }
        public decimal Tarifa { get; set; }
    }
}
