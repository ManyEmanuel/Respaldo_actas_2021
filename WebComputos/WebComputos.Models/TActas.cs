using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebComputos.Models
{
    public class TActas
    {
        [Key]
        public int IdActa { get; set; }

        [Display(Name = "[1] Boletas sobrantes de la elección:")]
        public int Sobrantes { get; set; }

        [Display(Name = "[2] Personas que votaron:")]
        public int VotosCiu { get; set; }

        [Display(Name = "[3] Representantes de partidos políticos y de candidatos/as independientes que votaron en la casilla no incluidos/as en la lista nominal:")]
        public int VotosRep { get; set; }

        [Display(Name = "[4] Suma de las cantidades de los apartados [2] y [3]:")]
        public int TotalVotos { get; set; }

        [Display(Name = "[5] Votos de la elección sacados de la urna:")]
        public int VotosUrnas { get; set; }
        
        public Boolean Incidentes { get; set; }
        public string DesIncidentes { get; set; }
        public int Computo { get; set; }

        [Display(Name = "Estatus en la que se recibió el acta:")]
        public int Estatus { get; set; }

        [ForeignKey("Estatus")]
        public EstatusActa LEstatus { get; set; }
        public int IdDetalleActa { get; set; }

        [ForeignKey("IdDetalleActa")]
        public DetallesActas LDetalleActa { get; set; }








    }
}
