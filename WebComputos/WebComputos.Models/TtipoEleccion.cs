using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace WebComputos.Models
{
    public class TtipoEleccion
    {
        [Key] 
        public int idTipoEleccion { get; set; }
        [Required(ErrorMessage ="El nombre del tipo elección es obligatorio")]
        public string Nombre { get; set; }
        [Required(ErrorMessage ="Las siglas del tipo elección son obligatorias")]
        [MaxLength(3)]
        public string Siglas { get; set; }
    }
}
