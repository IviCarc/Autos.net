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

        public int AutoClienteID { get; set; }
        [ForeignKey("AutoClienteID")]
        public virtual AutoCliente AutoCliente{ get; set; }


    }
}
