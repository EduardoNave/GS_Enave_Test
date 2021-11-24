using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace GS_Enave_Test.Models
{
    public class mat_materia
    {
        [Key]
        [Display(Name = "ID")]
        public int mat_id { get; set; }

        [Required(ErrorMessage = "Nombre de la materia requerido")]
        [StringLength(100, ErrorMessage = "El nombre no puede exceder los {1} caracteres")]
        [Display(Name = "Materia")]
        public string mat_nombre { get; set; }
    }
}
