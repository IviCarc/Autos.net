
using Autos.Models;
using Microsoft.EntityFrameworkCore;

namespace Autos.Data
{
    public class AutosAPIDbContext : DbContext
    {

        public AutosAPIDbContext() 
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

        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{
        //    optionsBuilder.UseSqlite(connectionString: "Filename=AutosDb.db",
        //        sqliteOptionsAction: op =>
        //        {
        //            op.MigrationsAssembly(Assembly.GetExecutingAssembly().FullName);
        //        });

        //    base.OnConfiguring(optionsBuilder);
        //}

        //protected override void OnModelCreating(ModelBuilder modelBuilder)
        //{
        //    base.OnModelCreating(modelBuilder);
        //}
    }
}
