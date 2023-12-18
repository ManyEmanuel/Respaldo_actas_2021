using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace WebComputos.Models
{
    public class TCoalicionDet
    {
        [Key]
        public int IdCoalicionDet { get; set; }
        [Required(ErrorMessage = "Seleccione el partido a agregar a la coalición")]
        public int Partido { get; set; }
        [Required(ErrorMessage ="La coalición es obligatoria")]
        public int Coalicion { get; set; }
        public bool Activo { get; set; }

        [ForeignKey("Partido")]
        public TPartidos LPartido { get; set; }
        [ForeignKey("Coalicion")]
        public TCoalicion LCoalicion { get; set; }


    }
}
