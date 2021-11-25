using GS_Enave_Test.Data;
using GS_Enave_Test.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;
using System.Linq;

namespace GS_Enave_Test.Controllers
{
    public class AlumnosController : Controller
    {
        private readonly ApplicationDbContext _context;

        public AlumnosController(ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            List<alm_alumno> alumnos = _context.alm_alumno.ToList();
            List<grd_grado> grados = _context.grd_grado.ToList();

            var alumnos_grados = from a in alumnos
                                 join g in grados on a.alm_id_grd equals g.grd_id into table1
                                 from g in table1.ToList()
                                 select new ListadoAlumno
                                 {
                                     Alumno = a,
                                     Grado = g                                     
                                 };
            return View(alumnos_grados);
        }

        //HTTP GET Create
        public IActionResult Create()
        {
            List<grd_grado> grados = _context.grd_grado.ToList();
            ViewBag.ListaGrados = grados;
            return View();
        }

        //HTTP POST Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(ListadoAlumno listadoAlumno)
        {
            if (ModelState.IsValid)
            {
                _context.alm_alumno.Add(listadoAlumno.Alumno);
                _context.SaveChanges();

                TempData["mensaje"] = "Alumno creado correctamente";
                return RedirectToAction("Index");
            }
            else
            {
                List<grd_grado> grados = _context.grd_grado.ToList();
                ViewBag.ListaGrados = grados;
                return View();
            }
        }

        //HTTP GET Edit
        public IActionResult Edit(int? id)
        {         
            if (id == null || id == 0)
                return NotFound();

            //obtenemos el Alumno
            var alumno = _context.alm_alumno.Find(id);

            if (alumno == null)
                return NotFound();

            var grado = _context.grd_grado.Find(alumno.alm_id_grd);

            //List<grd_grado> lista_grados = _context.grd_grado.ToList();
            //ViewBag.ListaGrados = lista_grados;

            var grados = _context.grd_grado.ToList();
            var lista_grados = new SelectList(grados.Select(item => new SelectListItem {
                Text = item.grd_nombre,
                Value = item.grd_id.ToString()
            }).ToList(), "Value", "Text");

            var listAlumno = new ListadoAlumno()
            {
                Alumno = alumno,
                Grado = grado,
                GradoSeleccionado = grado.grd_id,
                ListaDeGrados = lista_grados
            };

            return View(listAlumno);
        }

        //HTTP POST Edit
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(ListadoAlumno listadoAlumno)
        {
            if (ModelState.IsValid)
            {
                _context.alm_alumno.Update(listadoAlumno.Alumno);
                _context.SaveChanges();

                TempData["mensaje"] = "Alumno editado correctamente";
                return RedirectToAction("Index");
            }
            else
            {
                List<grd_grado> grados = _context.grd_grado.ToList();
                ViewBag.ListaGrados = grados;
                return View();
            }
        }

        //HTTP GET Delete
        public IActionResult Delete(int? id)
        {
            if (id == null || id == 0)
                return NotFound();

            //obtenemos el Alumno
            var alumno = _context.alm_alumno.Find(id);

            if (alumno == null)
                return NotFound();

            var grado = _context.grd_grado.Find(alumno.alm_id_grd);

            //List<grd_grado> lista_grados = _context.grd_grado.ToList();
            //ViewBag.ListaGrados = lista_grados;

            var grados = _context.grd_grado.ToList();
            var lista_grados = new SelectList(grados.Select(item => new SelectListItem
            {
                Text = item.grd_nombre,
                Value = item.grd_id.ToString()
            }).ToList(), "Value", "Text");

            var listAlumno = new ListadoAlumno()
            {
                Alumno = alumno,
                Grado = grado,
                GradoSeleccionado = grado.grd_id,
                ListaDeGrados = lista_grados
            };

            return View(listAlumno);
        }

        //HTTP POST Delete
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Delete(ListadoAlumno listadoAlumno)
        {
            _context.alm_alumno.Remove(listadoAlumno.Alumno);
            _context.SaveChanges();

            TempData["mensaje"] = "Alumno elimnado correctamente";
            return RedirectToAction("Index");
        }
    }
}
