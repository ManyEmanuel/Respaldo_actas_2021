using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace WebComputos.Models
{
    public class TCoalicion
    {
        [Key]
        public int IdCoalicion { get; set; }
        [Required(ErrorMessage ="El nombre de la coalición es obligatorio")]
        public string Nombre { get; set; }
        [Required(ErrorMessage ="Las siglas de la coalición son obligatorias")]
        public string Siglas { get; set; }
        public string Logo { get; set; }

    }
}
