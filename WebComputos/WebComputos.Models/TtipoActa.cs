using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace WebComputos.Models
{
    public class TtipoActa
    {
        [Key]
        public int IdActa { get; set; }
        [Required(ErrorMessage ="El nombre del tipo de acta es obligatorio")]
        public string Nombre { get; set; }
        [Required(ErrorMessage ="El tipo de elección es obligatorio")]
        public int TipoEleccion{ get; set; }
        [ForeignKey("TipoEleccion")]
        public TtipoEleccion LTipoEleccion { get; set; }
                
    }
}
