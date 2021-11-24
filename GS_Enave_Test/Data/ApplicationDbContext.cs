using GS_Enave_Test.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GS_Enave_Test.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }

        public DbSet<grd_grado> grd_grado { get; set; }

        public DbSet<alm_alumno> alm_alumno { get; set; }

        public DbSet<mat_materia> mat_materia { get; set; }

        public DbSet<mxg_materiasxgrado> mxg_materiasxgrado { get; set; }

    }
}
