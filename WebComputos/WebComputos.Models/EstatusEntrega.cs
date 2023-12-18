using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebComputos.Models
{
    public class EstatusEntrega
    {
        [Key]

        public int IdEstatusEntrega { get; set; }
        public int IdCasillaDet { get; set; }

        public string Paquetes { get; set; }
        public string Gobernador { get; set; }
        public string Pys { get; set; }
        public string Diputado { get; set; }
        public string Regidor { get; set; }

        [ForeignKey("IdCasillaDet")]
        public TCasillaDet LCasillaDet { get; set; }




    }
}
