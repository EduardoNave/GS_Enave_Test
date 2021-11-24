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
        public int mxg_id_grd { get; set; }
        public int mxg_id_mat { get; set; }
    }
}
