using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace WebComputos.Models
{
    public class TPartidos
    {
        [Key]
        public int IdPartido { get; set; }
        [Required(ErrorMessage ="El nombre del partido es obligatorio")]
        public string Nombre { get; set; }
        [Required]
        public string Siglas { get; set; }
        public string LogoURL { get; set; }
        public bool Independiente { get; set; }
        public int Prioridad { get; set; }
        [Required]
        public string PantoneF { get; set; }
        [Required]
        public string PantoneL { get; set; }

    }
}
