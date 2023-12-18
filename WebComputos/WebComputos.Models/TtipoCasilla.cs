using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace WebComputos.Models
{
    public class TtipoCasilla
    {
        [Key]
        public int IdTipoCasilla { get; set; }
        [Required(ErrorMessage ="El nombre del tipo casilla es obligatorio")]
        public string Nombre  { get; set; }
        [Required(ErrorMessage ="Las siglas son obligatorios")]
        public string Siglas { get; set; }
    }
}
