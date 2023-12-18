using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace WebComputos.Models
{
    public class TCasillaDet
    {
        [Key]
        public int IdCasillaDet { get; set; }
        public int Seccion { get; set; }
        public int TipoCasilla { get; set; }
        public int NoCasilla { get; set; }
        public int ExtContigua { get; set; }
        public int ListadoNominal { get; set; }
        public int PadronElec { get; set; }
        public int BoletasEnt { get; set; }
        public int Municipio { get; set; }
        public bool Activo { get; set; }
        public bool Capturado { get; set; }
        public string Nombre { get; set; }

        [ForeignKey("Seccion")]
        public TSeccion Lseccion { get; set; }

        [ForeignKey("TipoCasilla")]
        public TtipoCasilla LTipocasilla { get; set; }
        
    }
}
