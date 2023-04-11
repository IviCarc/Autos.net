using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Autos.Models
{
    public class AutoCliente
    {
        [Key]
        public int Id { get; set; }
        public string Patente { get; set; }

        [ForeignKey(nameof(ClienteId))]
        public int ClienteId { get; set; }

        [ForeignKey(nameof(AutoId))]
        public int AutoId { get; set; }



       
    }
}
