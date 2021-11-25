using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;

namespace GS_Enave_Test.Models
{
    public class ListaCompleta
    {
        public alm_alumno Alumno { get; set; }
        public grd_grado Grado { get; set; }
        public mat_materia Materia { get; set; }
        public mxg_materiasxgrado Materiasxgrado { get; set; }
        public int GradoSeleccionado { get; set; }
        public IEnumerable<SelectListItem> ListaDeGrados { get; set; }
    }
}
