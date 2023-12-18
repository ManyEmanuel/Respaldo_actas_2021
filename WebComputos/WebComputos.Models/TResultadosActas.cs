using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebComputos.Models
{
    public class TResultadosActas
    {
        [Key]
        public int IdResultadoActa { get; set; }
        public int IdPartido { get; set; }
        public int IdCoalicion { get; set; }
        public int IdCombinacion { get; set; }
        public int IdIndependiente { get; set; }
        public int NoRegistrados { get; set; }
        public int Nulos { get; set; }
        public int Total { get; set; }
        public int VotosRegistrados { get; set; }

        public int IdActa { get; set; }
        [ForeignKey("IdActa")]
        public TActas LRespuesta { get; set; }

    }
}
