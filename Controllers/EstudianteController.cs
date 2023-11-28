using EstudiantesAPP.Dominio.IServices;
using EstudiantesAPP.Servicios.Services;
using EstudiantesAPP.Transporte;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Globalization;

namespace EstudiantesApp.Controllers
{
    public class EstudianteController : Controller
    {
        private readonly IEstudianteService _IEstudianteService;

        public EstudianteController(IEstudianteService iEstudianteService)
        {
            _IEstudianteService = iEstudianteService;
        }
        // GET: EstudianteController
        public async Task<ActionResult> Index()
        {
            var estudiantes = await _IEstudianteService.ConsultaEstudiantes();
            return View(estudiantes);
        }

        // GET: EstudianteController/Details/5
        public async Task<ActionResult> Details(int id)
        {
            EstudianteDTO estudiante = await _IEstudianteService.ConsultaEstudiante(id);
            return View(estudiante);
        }

        // GET: EstudianteController/Create
        public ActionResult Create()
        
        {
            return View();
        }
        // POST: EstudianteController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(IFormCollection collection)
        {
            try
            {
                EstudianteDTO estudiante = Formulario(collection);
                var respuesta = await _IEstudianteService.CrearEstudiante(estudiante);
                
                //notifivcaciones
                if (respuesta == false)
                {
                    TempData["Error"] = "Ocurrio un error al crear";
                }
                else
                {
                    TempData["Exito"] = "Creación exitosa";
                }

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
        // GET: EstudianteController/Edit/5
        public async Task<ActionResult> Edit(int id)
        {
            EstudianteDTO estudiante = await _IEstudianteService.ConsultaEstudiante(id);
            return View(estudiante);
        }

        // POST: EstudianteController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(int id, IFormCollection collection)
        {
            try
            {
                EstudianteDTO estudiante = Formulario(collection);
                var fecha = "" + collection["FechaDate"];
                var fechaDate = DateTime.Parse(fecha);
                estudiante.FechaInscripcion = fechaDate.ToString("dd/MM/yyyy", CultureInfo.InvariantCulture);
                var respuesta = await _IEstudianteService.EditarEstudiante(estudiante);
                //notificacion
                if (respuesta == false)
                {
                    TempData["Error"] = "Ocurrió un error en la edición";
                }
                else
                {
                    TempData["Exito"] = "Edición exitosa";
                }

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
        private EstudianteDTO Formulario(IFormCollection collection)
        {
            return new EstudianteDTO
            {
                Id = int.Parse(string.IsNullOrEmpty(collection["Id"]) ? "0" : collection["Id"]),
                Nombres = collection["Nombres"],
                Apellidos = collection["Apellidos"],
                FechaInscripcion = collection["FechaInscripcion"],
            };
        }

        // GET: EstudianteController/Delete/5
        public async Task<ActionResult> Delete(int id)
        {
            EstudianteDTO estudiante = await _IEstudianteService.ConsultaEstudiante(id);
            return View(estudiante);
        }
        // POST: EstudianteController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Delete(int id, IFormCollection collection)
        {
            try
            {
                var respuesta = await _IEstudianteService.EliminarEstudiante(id);

                //notificacion
                if (respuesta == false)
                {
                    TempData["Error"] = "Ocurrió un error en la eliminación";
                }
                else
                {
                    TempData["Exito"] = "Eliminación exitosa";
                }

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
