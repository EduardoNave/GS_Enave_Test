using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace GS_Enave_Test.Models
{
    public class alm_alumno
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Display(Name = "ID")]
        public int alm_id { get; set; }

        [Required(ErrorMessage = "Código de identificación requerido")]
        [StringLength(100, ErrorMessage = "El código no puede exceder los {1} caracteres")]
        [Display(Name = "Código")]
        public string alm_codigo { get; set; }

        [Required(ErrorMessage = "Nombre requerido")]
        [StringLength(300, ErrorMessage = "El nombre no puede exceder los {1} caracteres")]
        [Display(Name = "Nombre")]
        public string alm_nombre { get; set; }

        [Required(ErrorMessage = "La edad es requerida")]
        [Display(Name = "Edad")]
        public int alm_edad { get; set; }

        [Required(ErrorMessage = "Por favor indicar el sexo")]
        [Display(Name = "Sexo")]
        public string alm_sexo { get; set; }

        [Required(ErrorMessage = "Indicar el grado al que pertenece")]
        [Display(Name = "Grado")]
        public int alm_id_grd { get; set; }

        [Display(Name = "Observación")]
        public string alm_observacion { get; set; }
    }
}
