using EstudiantesAPP.Transporte;

namespace EstudiantesAPP.Dominio.IRepositories
{
    public interface IEstudianteRepository
    {
        Task<EstudianteDTO> ConsultaEstudiante(int id);
        Task<List<EstudianteDTO>> ConsultaEstudiantes();
        Task<bool> CrearEstudiante(EstudianteDTO estudiante);
        Task<bool> EditarEstudiante(EstudianteDTO estudiante);
        Task<bool> EliminarEstudiante(int id);
    }
}
