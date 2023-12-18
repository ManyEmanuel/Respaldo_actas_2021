using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace WebComputos.Models
{
    public class TMunicipio
    {
        [Key]
        public int IdMunicipio { get; set; }
        public string Nombre { get; set; }

        [Display(Name ="Cabecera municipal")]
        public string CabMun { get; set; }

        [Display(Name ="No Estado")]
        public int NoEstado { get; set; }
        public string Estado { get; set; }
    }
}
