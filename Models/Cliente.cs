using System.ComponentModel.DataAnnotations;

namespace Autos.Models
{
    public class Cliente
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; } 
    }
}
