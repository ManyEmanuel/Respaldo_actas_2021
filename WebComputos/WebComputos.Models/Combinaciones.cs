using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace WebComputos.Models
{
    public class Combinaciones
    {
        [Key]
        public int idCombinacion { get; set; }
        public int Coalicion { get; set; }
        public string Combinacion { get; set; }
        public int Tamaño { get; set; }
        public string LogoURL { get; set; }
       
        [ForeignKey("Coalicion")]
        public TCoalicion bdCoalicion { get; set; }


    }
}
