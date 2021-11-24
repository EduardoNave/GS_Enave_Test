using GS_Enave_Test.Data;
using GS_Enave_Test.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GS_Enave_Test.Controllers
{
    public class MateriasController : Controller
    {
        private readonly ApplicationDbContext _context;

        public MateriasController(ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            IEnumerable<mat_materia> materias = _context.mat_materia;
            return View(materias);
        }

        //HTTP GET Create
        public IActionResult Create()
        {
            return View();
        }

        //HTTP POST Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(mat_materia mat_materia)
        {
            if (ModelState.IsValid)
            {
                _context.mat_materia.Add(mat_materia);
                _context.SaveChanges();

                TempData["mensaje"] = "Materia creada correctamente";
                return RedirectToAction("Index");
            }

            return View();
        }

        //HTTP GET Edit
        public IActionResult Edit(int? id)
        {
            if (id == null || id == 0)
                return NotFound();

            //obtenemos el Materia
            var materia = _context.mat_materia.Find(id);

            if (materia == null)
                return NotFound();

            return View(materia);
        }

        //HTTP POST Edit
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(mat_materia alm_Materia)
        {
            if (ModelState.IsValid)
            {
                _context.mat_materia.Update(alm_Materia);
                _context.SaveChanges();

                TempData["mensaje"] = "Materia editada correctamente";
                return RedirectToAction("Index");
            }

            return View();
        }

        //HTTP GET Delete
        public IActionResult Delete(int? id)
        {
            if (id == null || id == 0)
                return NotFound();

            //obtenemos la materia
            var materia = _context.mat_materia.Find(id);

            if (materia == null)
                return NotFound();

            return View(materia);
        }

        //HTTP POST Edit
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteMateria(int? id)
        {
            //se obtiene el Materia
            var materia = _context.mat_materia.Find(id);

            if (materia == null)
                return NotFound();

            _context.mat_materia.Remove(materia);
            _context.SaveChanges();

            TempData["mensaje"] = "Materia eliminada correctamente";
            return RedirectToAction("Index");
        }
    }
}
