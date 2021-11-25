using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;

namespace GS_Enave_Test.Models
{
    public class ListadoAlumno
    {
        public alm_alumno Alumno { get; set; }
        public grd_grado Grado { get; set; }
        public int GradoSeleccionado { get; set; }
        public IEnumerable<SelectListItem> ListaDeGrados { get; set; }
    }
}
