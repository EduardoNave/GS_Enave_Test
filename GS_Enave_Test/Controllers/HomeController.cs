using GS_Enave_Test.Data;
using GS_Enave_Test.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

namespace GS_Enave_Test.Controllers
{
    public class HomeController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger, ApplicationDbContext context)
        {
            _logger = logger;
            _context = context;
        }

        public IActionResult Index()
        {
            List<alm_alumno> alumnos = _context.alm_alumno.ToList();
            List<mat_materia> materias = _context.mat_materia.ToList();
            List<grd_grado> grados = _context.grd_grado.ToList();
            List<mxg_materiasxgrado> materiasxgrados = _context.mxg_materiasxgrado.ToList();
            ViewBag.ListaGrados = grados;
            var materias_alumnos = from a in alumnos
                                    join mx in materiasxgrados on a.alm_id_grd equals mx.mxg_id_grd into table1
                                    from mx in table1.ToList()
                                    join m in materias on mx.mxg_id_mat equals m.mat_id into table2
                                    from m in table2.ToList()
                                    join g in grados on mx.mxg_id_grd equals g.grd_id into table3
                                    from g in table3.ToList()
                                    select new ListaCompleta
                                    {
                                        Alumno = a,
                                        Grado = g,
                                        Materia = m,
                                        Materiasxgrado = mx
                                    };
            return View(materias_alumnos);
        }

        [HttpPost]
        public IActionResult Index(string filt_codigo, int filt_grado, string filt_sexo)
        {
            List<alm_alumno> alumnos = _context.alm_alumno.ToList();
            List<mat_materia> materias = _context.mat_materia.ToList();
            List<grd_grado> grados = _context.grd_grado.ToList();
            List<mxg_materiasxgrado> materiasxgrados = _context.mxg_materiasxgrado.ToList();
            ViewBag.ListaGrados = grados;

            if (!String.IsNullOrEmpty(filt_codigo))
            {
                if (filt_grado > 0)
                {
                    var materias_alumnos = from a in alumnos
                                           join mx in materiasxgrados on a.alm_id_grd equals mx.mxg_id_grd into table1
                                           from mx in table1.ToList()
                                           join m in materias on mx.mxg_id_mat equals m.mat_id into table2
                                           from m in table2.ToList()
                                           join g in grados on mx.mxg_id_grd equals g.grd_id into table3
                                           from g in table3.ToList()
                                           where a.alm_codigo.Contains(filt_codigo)
                                           where mx.mxg_id_grd.Equals(filt_grado)
                                           select new ListaCompleta
                                           {
                                               Alumno = a,
                                               Grado = g,
                                               Materia = m,
                                               Materiasxgrado = mx
                                           };
                    return View(materias_alumnos);
                }
                else
                {
                    var materias_alumnos = from a in alumnos
                                           join mx in materiasxgrados on a.alm_id_grd equals mx.mxg_id_grd into table1
                                           from mx in table1.ToList()
                                           join m in materias on mx.mxg_id_mat equals m.mat_id into table2
                                           from m in table2.ToList()
                                           join g in grados on mx.mxg_id_grd equals g.grd_id into table3
                                           from g in table3.ToList()
                                           where a.alm_codigo.Contains(filt_codigo)
                                           select new ListaCompleta
                                           {
                                               Alumno = a,
                                               Grado = g,
                                               Materia = m,
                                               Materiasxgrado = mx
                                           };
                    return View(materias_alumnos);
                }
            }
            else if (!String.IsNullOrEmpty(filt_sexo))
            {
                if (filt_grado > 0)
                {
                    var materias_alumnos = from a in alumnos
                                           join mx in materiasxgrados on a.alm_id_grd equals mx.mxg_id_grd into table1
                                           from mx in table1.ToList()
                                           join m in materias on mx.mxg_id_mat equals m.mat_id into table2
                                           from m in table2.ToList()
                                           join g in grados on mx.mxg_id_grd equals g.grd_id into table3
                                           from g in table3.ToList()
                                           where a.alm_sexo.Contains(filt_sexo)
                                           where mx.mxg_id_grd.Equals(filt_grado)
                                           select new ListaCompleta
                                           {
                                               Alumno = a,
                                               Grado = g,
                                               Materia = m,
                                               Materiasxgrado = mx
                                           };
                    return View(materias_alumnos);
                }
                else
                {
                    var materias_alumnos = from a in alumnos
                                           join mx in materiasxgrados on a.alm_id_grd equals mx.mxg_id_grd into table1
                                           from mx in table1.ToList()
                                           join m in materias on mx.mxg_id_mat equals m.mat_id into table2
                                           from m in table2.ToList()
                                           join g in grados on mx.mxg_id_grd equals g.grd_id into table3
                                           from g in table3.ToList()
                                           where a.alm_sexo.Contains(filt_sexo)
                                           select new ListaCompleta
                                           {
                                               Alumno = a,
                                               Grado = g,
                                               Materia = m,
                                               Materiasxgrado = mx
                                           };
                    return View(materias_alumnos);
                }
            }
            else
            {
                if (filt_grado > 0)
                {
                    var materias_alumnos = from a in alumnos
                                           join mx in materiasxgrados on a.alm_id_grd equals mx.mxg_id_grd into table1
                                           from mx in table1.ToList()
                                           join m in materias on mx.mxg_id_mat equals m.mat_id into table2
                                           from m in table2.ToList()
                                           join g in grados on mx.mxg_id_grd equals g.grd_id into table3
                                           from g in table3.ToList()
                                           where mx.mxg_id_grd.Equals(filt_grado)
                                           select new ListaCompleta
                                           {
                                               Alumno = a,
                                               Grado = g,
                                               Materia = m,
                                               Materiasxgrado = mx
                                           };
                    return View(materias_alumnos);
                }
                else
                {
                    var materias_alumnos = from a in alumnos
                                           join mx in materiasxgrados on a.alm_id_grd equals mx.mxg_id_grd into table1
                                           from mx in table1.ToList()
                                           join m in materias on mx.mxg_id_mat equals m.mat_id into table2
                                           from m in table2.ToList()
                                           join g in grados on mx.mxg_id_grd equals g.grd_id into table3
                                           from g in table3.ToList()
                                           select new ListaCompleta
                                           {
                                               Alumno = a,
                                               Grado = g,
                                               Materia = m,
                                               Materiasxgrado = mx
                                           };
                    return View(materias_alumnos);
                }
            }
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
