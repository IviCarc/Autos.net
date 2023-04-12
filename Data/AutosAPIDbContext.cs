
using Autos.Models;
using Microsoft.EntityFrameworkCore;
namespace Autos.Data
{
    public class AutosAPIDbContext : DbContext
    {

        public AutosAPIDbContext() : base()
        {
        }
        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            options.UseSqlite("Data Source=AutosAPI.db");
        }
        public DbSet<Auto> Autos { get; set; }
        public DbSet<Cliente> Clientes{ get; set; }
        public DbSet<AutoCliente> AutoClientes{ get; set; }
        public DbSet<Reparacion> Reparaciones { get; set; }
    }
}
