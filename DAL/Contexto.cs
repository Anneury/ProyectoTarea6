using Microsoft.EntityFrameworkCore;
using ProyectoTarea6.Entidades;

namespace ProyectoTarea6.DAL
{
    public class Contexto : DbContext
    {
        public DbSet<Permisos> Permisos { get; set; }
        public DbSet<Roles> Roles { get; set; }
        public DbSet<Usuarios> Usuarios { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite(@"Data Source = DATA\GestionDatos.Db");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Permisos>().HasData(
                new Permisos() { PermisoID = 1, NombrePermiso = "Descuenta", DescripcionPermiso = "Este permiso puede modificar el precio" },
                new Permisos() { PermisoID = 2, NombrePermiso = "Vende", DescripcionPermiso = "Este permiso puede vender productos" },
                new Permisos() { PermisoID = 3, NombrePermiso = "Cobra", DescripcionPermiso = "Este permiso puede cobrar dinero" }
            );
        }
    }
}
