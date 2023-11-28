using EstudiantesAPP.Dominio.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Internal;

namespace EstudiantesAPP.Persistencia.Context
{
    public class AplicationDBContext:DbContext
    {   
        public DbSet<Estudiante> Estudiante { get; set; }

        public AplicationDBContext(DbContextOptions<AplicationDBContext> options):base(options)
        {
            
        }
        protected override void OnModelCreating(ModelBuilder builder) 
        {
            base.OnModelCreating(builder);
        }
    }
}
