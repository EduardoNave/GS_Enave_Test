using GS_Enave_Test.Data;
using GS_Enave_Test.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GS_Enave_Test.Controllers
{
    public class MateriasxGradoController : Controller
    {
        private readonly ApplicationDbContext _context;

        public MateriasxGradoController(ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            IEnumerable<mxg_materiasxgrado> materiasxgrado = _context.mxg_materiasxgrado;
            return View(materiasxgrado);
        }

        //HTTP GET Create
        public IActionResult Create()
        {
            return View();
        }

        //HTTP POST Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(mxg_materiasxgrado mxg_materiasxgrado)
        {
            if (ModelState.IsValid)
            {
                _context.mxg_materiasxgrado.Add(mxg_materiasxgrado);
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
            var materiaxgrado = _context.mxg_materiasxgrado.Find(id);

            if (materiaxgrado == null)
                return NotFound();

            return View(materiaxgrado);
        }

        //HTTP POST Edit
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(mxg_materiasxgrado alm_Materia)
        {
            if (ModelState.IsValid)
            {
                _context.mxg_materiasxgrado.Update(alm_Materia);
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
            var materiaxgrado = _context.mxg_materiasxgrado.Find(id);

            if (materiaxgrado == null)
                return NotFound();

            return View(materiaxgrado);
        }

        //HTTP POST Edit
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteMateria(int? id)
        {
            //se obtiene el Materia
            var materiaxgrado = _context.mxg_materiasxgrado.Find(id);

            if (materiaxgrado == null)
                return NotFound();

            _context.mxg_materiasxgrado.Remove(materiaxgrado);
            _context.SaveChanges();

            TempData["mensaje"] = "Materia eliminada correctamente";
            return RedirectToAction("Index");
        }
    }
}
