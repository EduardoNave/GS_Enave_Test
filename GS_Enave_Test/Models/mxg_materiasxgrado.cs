using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace GS_Enave_Test.Models
{
    public class mxg_materiasxgrado
    {
        [Key]
        public int mxg_id { get; set; }
        
        [Required(ErrorMessage = "Seleccione el grado de la materia")]
        [Display(Name = "Grado")]
        public int mxg_id_grd { get; set; }

        [Required(ErrorMessage = "Seleccione la materia a agregar")]
        [Display(Name = "Materia")]
        public int mxg_id_mat { get; set; }
    }
}
