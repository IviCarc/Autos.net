using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Autos.Models
{
    public class Reparacion
    {
        [Key]
        public int Id { get; set; }
        public DateOnly Fecha { get; set; }
        public int Km { get; set; }
        public string Trabajo { get; set; }

        [ForeignKey(nameof(AutoClienteId))]
        public int AutoClienteId { get; set; }
    }
}
