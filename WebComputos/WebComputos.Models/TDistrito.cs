using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace WebComputos.Models
{
    public class TDistrito
    {
        [Key]
        public int IdDistrito { get; set; }
        [Required(ErrorMessage ="El nombre del distrito es obligatorio")]
        [Display(Name ="Nombre distrito")]
        public int NoDistrito { get; set; }
        public string Nombre { get; set; }
        public string Integracion { get; set; }      

    }
}
