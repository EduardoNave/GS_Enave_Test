using GS_Enave_Test.Data;
using GS_Enave_Test.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GS_Enave_Test.Controllers
{
    public class GradosController : Controller
    {
        private readonly ApplicationDbContext _context;

        public GradosController(ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            IEnumerable<grd_grado> grados = _context.grd_grado;
            return View(grados);
        }

        //HTTP GET Create
        public IActionResult Create()
        {
            return View();
        }

        //HTTP POST Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(grd_grado grd_Grado)
        {
            if (ModelState.IsValid)
            {
                _context.grd_grado.Add(grd_Grado);
                _context.SaveChanges();

                TempData["mensaje"] = "Grado creado correctamente";
                return RedirectToAction("Index");
            }

            return View();
        }

        //HTTP GET Edit
        public IActionResult Edit(int? id)
        {
            if (id == null || id == 0)
                return NotFound();

            //obtenemos el grado
            var grado = _context.grd_grado.Find(id);

            if (grado == null)
                return NotFound();

            return View(grado);
        }

        //HTTP POST Edit
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(grd_grado grd_Grado)
        {
            if (ModelState.IsValid)
            {
                _context.grd_grado.Update(grd_Grado);
                _context.SaveChanges();

                TempData["mensaje"] = "Grado editado correctamente";
                return RedirectToAction("Index");
            }

            return View();
        }

        //HTTP GET Delete
        public IActionResult Delete(int? id)
        {
            if (id == null || id == 0)
                return NotFound();

            //obtenemos el grado
            var grado = _context.grd_grado.Find(id);

            if (grado == null)
                return NotFound();

            return View(grado);
        }

        //HTTP POST Edit
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteGrado(int? id)
        {
            //se obtiene el grado
            var grado = _context.grd_grado.Find(id);

            if (grado == null)
                return NotFound();

            _context.grd_grado.Remove(grado);
            _context.SaveChanges();

            TempData["mensaje"] = "Grado eliminado correctamente";
            return RedirectToAction("Index");
        }
    }
}
