using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace WebComputos.Models
{
    public class TDemarcacion
    {
        [Key]
        public int idDemarcacion { get; set; }
        [Required(ErrorMessage ="El nombre de la demarcación es obligatorio")]
        public string Nombre { get; set; }
        
        [Required(ErrorMessage ="El numero de la demarcacíon es obligatorio")]
        public int noDemarcacion { get; set; }
        public Boolean Redemarcacion { get; set; }

        [Required(ErrorMessage = "El municipio es obligatorio")]
        [Display(Name ="Municipio")]
        public int? Municipio { get; set; }

        [ForeignKey("Municipio")]
        public TMunicipio Municipios { get; set; }
    }
}
