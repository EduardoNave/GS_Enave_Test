using GS_Enave_Test.Data;
using GS_Enave_Test.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

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
            IEnumerable<alm_alumno> alumnos = _context.alm_alumno;
            return View(alumnos);
        }

        //HTTP GET Create
        public IActionResult Create()
        {
            return View();
        }

        //HTTP POST Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(alm_alumno alm_alumno)
        {
            if (ModelState.IsValid)
            {
                _context.alm_alumno.Add(alm_alumno);
                _context.SaveChanges();

                TempData["mensaje"] = "Alumno creado correctamente";
                return RedirectToAction("Index");
            }

            return View();
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

            return View(alumno);
        }

        //HTTP POST Edit
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(alm_alumno alm_Alumno)
        {
            if (ModelState.IsValid)
            {
                _context.alm_alumno.Update(alm_Alumno);
                _context.SaveChanges();

                TempData["mensaje"] = "Alumno editado correctamente";
                return RedirectToAction("Index");
            }

            return View();
        }

        //HTTP GET Delete
        public IActionResult Delete(int? id)
        {
            if (id == null || id == 0)
                return NotFound();

            //obtenemos el alumno
            var alumno = _context.alm_alumno.Find(id);

            if (alumno == null)
                return NotFound();

            return View(alumno);
        }

        //HTTP POST Edit
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteAlumno(int? id)
        {
            //se obtiene el Alumno
            var alumno = _context.alm_alumno.Find(id);

            if (alumno == null)
                return NotFound();

            _context.alm_alumno.Remove(alumno);
            _context.SaveChanges();

            TempData["mensaje"] = "Alumno eliminado correctamente";
            return RedirectToAction("Index");
        }
    }
}
