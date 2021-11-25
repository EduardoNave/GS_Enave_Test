using GS_Enave_Test.Data;
using GS_Enave_Test.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
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
            List<mxg_materiasxgrado> mxg_s = _context.mxg_materiasxgrado.ToList();
            List<mat_materia> materias = _context.mat_materia.ToList();
            List<grd_grado> grados = _context.grd_grado.ToList();

            var materias_grados = from mxg in mxg_s 
                                  join m in materias on mxg.mxg_id_mat equals m.mat_id into table1
                                  from m in table1.ToList()
                                  join g in grados on mxg.mxg_id_grd equals g.grd_id into table2
                                  from g in table2.ToList()
                                  select new ListaMxG
                                  {
                                      Materiasxgrado = mxg,
                                      Grado = g,
                                      Materia = m
                                  };
            return View(materias_grados);
        }

        //HTTP GET Create
        public IActionResult Create()
        {
            List<grd_grado> grados = _context.grd_grado.ToList();
            ViewBag.ListaGrados = grados;
            List<mat_materia> materias = _context.mat_materia.ToList();
            ViewBag.ListaMaterias = materias;
            return View();
        }

        //HTTP POST Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(ListaMxG listaMxG)
        {
            if (ModelState.IsValid)
            {
                _context.mxg_materiasxgrado.Add(listaMxG.Materiasxgrado);
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

            var grados = _context.grd_grado.ToList();
            var materias = _context.mat_materia.ToList();
            var lista_grados = new SelectList(grados.Select(item => new SelectListItem
            {
                Text = item.grd_nombre,
                Value = item.grd_id.ToString()
            }).ToList(), "Value", "Text");
            var lista_materias = new SelectList(materias.Select(item => new SelectListItem
            {
                Text = item.mat_nombre,
                Value = item.mat_id.ToString()
            }).ToList(), "Value", "Text");

            var listMateriaxGrado = new ListaMxG()
            {
                Materiasxgrado = materiaxgrado,
                MateriaSeleccionada = materiaxgrado.mxg_id_mat,
                GradoSeleccionado = materiaxgrado.mxg_id_grd,
                ListaDeGrados = lista_grados,
                ListaDeMaterias = lista_materias
            };

            return View(listMateriaxGrado);
        }

        //HTTP POST Edit
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(ListaMxG listaMxG)
        {
            if (ModelState.IsValid)
            {
                _context.mxg_materiasxgrado.Update(listaMxG.Materiasxgrado);
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

            //obtenemos el Materia
            var materiaxgrado = _context.mxg_materiasxgrado.Find(id);

            if (materiaxgrado == null)
                return NotFound();

            var grados = _context.grd_grado.ToList();
            var materias = _context.mat_materia.ToList();
            var lista_grados = new SelectList(grados.Select(item => new SelectListItem
            {
                Text = item.grd_nombre,
                Value = item.grd_id.ToString()
            }).ToList(), "Value", "Text");
            var lista_materias = new SelectList(materias.Select(item => new SelectListItem
            {
                Text = item.mat_nombre,
                Value = item.mat_id.ToString()
            }).ToList(), "Value", "Text");

            var listMateriaxGrado = new ListaMxG()
            {
                Materiasxgrado = materiaxgrado,
                MateriaSeleccionada = materiaxgrado.mxg_id_mat,
                GradoSeleccionado = materiaxgrado.mxg_id_grd,
                ListaDeGrados = lista_grados,
                ListaDeMaterias = lista_materias
            };

            return View(listMateriaxGrado);
        }

        //HTTP POST Edit
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Delete(ListaMxG listaMxG)
        {
            _context.mxg_materiasxgrado.Remove(listaMxG.Materiasxgrado);
            _context.SaveChanges();

            TempData["mensaje"] = "Materia eliminada correctamente";
            return RedirectToAction("Index");
        }
    }
}
