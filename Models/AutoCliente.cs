using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Autos.Models
{
    public class AutoCliente
    {
        public int Id { get; set; }
        public string Patente { get; set; }
        public int ClienteID { get; set; }
        [ForeignKey("ClienteID")]
        public virtual Cliente Cliente { get; set; }

        public int AutoID { get; set; }
        [ForeignKey("AutoID")]
        public virtual Auto Auto{ get; set; }
       
    }
}
