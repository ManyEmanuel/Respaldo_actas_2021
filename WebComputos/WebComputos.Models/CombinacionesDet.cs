using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace WebComputos.Models
{
    public class CombinacionesDet
    {
        [Key]
        public int idCombinacionesDet { get; set; }
        public int Combinacion { get; set; }
        public int Partido { get; set; }
        [ForeignKey ("Partido")]
        public TPartidos bdPartido { get; set; }
        [ForeignKey("Combinacion")]
        public Combinaciones bdCombinacion { get; set; }
    }
}
