using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebComputos.Models
{
    public class RecepcionDetalle
    {
        [Key]

        public int IdRecepcionDetalle { get; set; }
        public int IdPaquete { get; set; }
        public int  IdEleccion { get; set; }

        [ForeignKey("IdPaquete")]
        public TRecepcionPaquetes LRecepcionDet { get; set; }
        
        [ForeignKey("IdEleccion")]
        public TtipoEleccion LtipoEleccion { get; set; }

    }
}
