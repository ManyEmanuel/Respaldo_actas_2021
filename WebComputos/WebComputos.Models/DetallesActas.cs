using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebComputos.Models
{
   public class DetallesActas
    {
        [Key]

        public int IdActaDetalle { get; set; }
        public int IdCasillaDet { get; set; }
        public int IdEleccion { get; set; }
        public Boolean Capturado { get; set; }

        [ForeignKey("IdCasillaDet")]
        public TCasillaDet LRecepcionDet { get; set; }

        [ForeignKey("IdEleccion")]
        public TtipoEleccion LtipoEleccion { get; set; }

    }
}

