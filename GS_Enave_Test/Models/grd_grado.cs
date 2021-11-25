using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace GS_Enave_Test.Models
{
    public class grd_grado
    {
        
        [Key]
        [Display(Name = "Id")] 
        public int grd_id { get; set; }

        [Required(ErrorMessage = "Descripción del grado requerida (Nombre)")]
        [StringLength(100, ErrorMessage = "El nombre no puede exceder los {1} caracteres")]
        [Display(Name = "Grado")]
        public string grd_nombre { get; set; }

        public static implicit operator grd_grado(List<grd_grado> v)
        {
            throw new NotImplementedException();
        }
    }
}
