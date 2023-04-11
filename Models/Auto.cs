using System.ComponentModel.DataAnnotations;

namespace Autos.Models
{
    public class Auto
    {
        [Key]
        public int Id { get; set; }
        public string Modelo { get; set; }
    }
}
