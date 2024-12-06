using DataModels;
using Exam2Rex.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using static DataModels.PrograVIDBStoredProcedures;

namespace Exam2Rex.Controllers
{
    public class EstudiantesController : Controller
    {
        // GET: Estudiantes        
        public ActionResult Lista()
        {
            return View();
        }

        // Fetch all students with their grades and location details
        public JsonResult RetornaEstudiantes()
        {
            var estudiantes = new List<ModelEstudiante>();
            using (var db = new PrograVIDB("MyDatabase"))
            {
                estudiantes = db.ObtenerEstudiantesConNotas()
                                .Select(e => new ModelEstudiante
                                {
                                    Estudiante = e.Estudiante,
                                    Nota = e.Nota,
                                    Distrito = e.Distrito,
                                    Canton = e.Canton,
                                    Provincia = e.Provincia
                                })
                                .ToList();
            }
            return Json(estudiantes, JsonRequestBehavior.AllowGet);
        }


        // Fetch all provinces for dropdown
        public JsonResult RetornaProvincias()
        {
            var provincias = new List<DropDown>();
            using (var db = new PrograVIDB("MyDatabase"))
            {
                provincias = db.ObtenerProvincias()
                               .Select(p => new DropDown
                               {
                                   Id = p.IdProvincia,
                                   Nombre = p.NombreProvincia
                               })
                               .ToList();
            }
            return Json(provincias, JsonRequestBehavior.AllowGet);
        }

        // Fetch cantons based on province ID
        public JsonResult RetornaCantones(int idProvincia)
        {
            var cantones = new List<DropDown>();
            using (var db = new PrograVIDB("MyDatabase"))
            {
                cantones = db.ObtenerCantonesPorProvincia(idProvincia)
                             .Select(c => new DropDown
                             {
                                 Id = c.IdCanton,
                                 Nombre = c.NombreCanton
                             })
                             .ToList();
            }
            return Json(cantones, JsonRequestBehavior.AllowGet);
        }

        // Fetch districts based on canton ID
        public JsonResult RetornaDistritos(int idCanton)
        {
            var distritos = new List<DropDown>();
            using (var db = new PrograVIDB("MyDatabase"))
            {
                distritos = db.ObtenerDistritosPorCanton(idCanton)
                              .Select(d => new DropDown
                              {
                                  Id = d.IdDistrito,
                                  Nombre = d.NombreDistrito
                              })
                              .ToList();
            }
            return Json(distritos, JsonRequestBehavior.AllowGet);
        }

        // Insert a new student record
        [HttpPost]
        public JsonResult InsertaEstudiante(
    string nombre,
    int idDistrito,
    decimal pruebaParcial1,
    decimal pruebaParcial2,
    decimal asignacion,
    decimal proyecto,
    decimal trabajoInvestigacion)
        {
            try
            {
                // Calculate weighted scores
                decimal weightedPruebaParcial1 = pruebaParcial1 * 0.15m;
                decimal weightedPruebaParcial2 = pruebaParcial2 * 0.15m;
                decimal weightedAsignacion = asignacion * 0.15m;
                decimal weightedProyecto = proyecto * 0.40m;
                decimal weightedTrabajoInvestigacion = trabajoInvestigacion * 0.15m;

                using (var db = new PrograVIDB("MyDatabase"))
                {
                    var result = db.InsertarEstudiante(
                        nombre,
                        idDistrito,
                        weightedPruebaParcial1,
                        weightedPruebaParcial2,
                        weightedAsignacion,
                        weightedProyecto,
                        weightedTrabajoInvestigacion
                    );
                }

                return Json(new { success = true, message = "Estudiante insertado correctamente" });
            }
            catch (Exception ex)
            {
                return Json(new { success = false, message = $"Error: {ex.Message}" });
            }
        }

    }
}