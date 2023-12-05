using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EstudiantesAPP.Transporte
{
    public class AccesoDTO
    {
        public int Id { get; set; }

        [Display(Name = "Nombre(s) del alumno")]

        public string? Email { get; set; }

        [Display(Name = "Apellido(s) del alumno")]

        public string? Password { get; set; }

        [NotMapped]
        public bool MantenerActivo { get; set; }
    }
}
