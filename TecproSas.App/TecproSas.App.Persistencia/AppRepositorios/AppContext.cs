using Microsoft.EntityFrameworkCore;
using TecproSas.App.Dominio;

namespace TecproSas.App.Persistencia
{
    public class AppContext : DbContext
    {
        public DbSet<Cliente> clientes {get; set;}
        public DbSet<Usuario> usuarios {get; set;}
        public DbSet<Fase> fases {get; set;}
        public DbSet<Proyecto> proyectos {get; set;}
        public DbSet<Servicio> servicios { get; set;}
        public DbSet<Login> logins { get; set;}

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        { 
            if (!optionsBuilder.IsConfigured)
            {
            optionsBuilder.UseSqlServer("Data Source= (localdb)\\MSSQLLocalDB; Initial catalog=PROYECTO_CICLO_3");
        
            }
        }

    }
}
