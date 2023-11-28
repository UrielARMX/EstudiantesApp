using EstudiantesAPP.Transporte;

namespace EstudiantesAPP.Dominio.IServices
{
    public interface IEstudianteService
    {
        Task<EstudianteDTO> ConsultaEstudiante(int id);
        Task <List<EstudianteDTO>>ConsultaEstudiantes();
        Task <bool>CrearEstudiante(EstudianteDTO estudiante);
        Task<bool> EditarEstudiante(EstudianteDTO estudiante);
        Task<bool> EliminarEstudiante(int id);
    }
}
