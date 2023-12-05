using EstudiantesAPP.Dominio.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Internal;

namespace EstudiantesAPP.Persistencia.Context
{
    public class AplicationDBContext:DbContext
    {   
        public string Conexion { set; get; }
        public DbSet<Estudiante> Estudiante { get; set; }
        public DbSet<Acceso> Acceso { get; set; }

        public AplicationDBContext(DbContextOptions<AplicationDBContext> options):base(options)
        {
            
        }
        public AplicationDBContext(string valor) {
            Conexion = valor;
        }
        protected override void OnModelCreating(ModelBuilder builder) 
        {
            base.OnModelCreating(builder);
        }
    }
}
