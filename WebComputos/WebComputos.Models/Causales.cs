using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebComputos.Models
{
    public class Causales
    {
        [Key]
        public int IdCausales { get; set; }
        public int IdCasillaDet { get; set; }
        public int IdEleccion { get; set; }
        public string PaqSinAec {get;set;}
        public string VotosNMayor{get;set;}
        public string VotosSisBol{get;set;}
        public string VotosSisAec{get;set;}
        public string VotosPartido{get;set;}
        public string ActaIlegible{get;set;}
        public string ActAlteraciones{get;set;}
        public string PaqAlteraciones{get;set;}
        public string CiuVotaron{get;set;}
        public string BoletasSisCiu{get;set;}
        public string BoletasSisTot{get;set;}
        public int NumCausales { get; set; }

        [ForeignKey("IdCasillaDet")]
        public TCasillaDet LCasillaDet { get; set; }
        
        [ForeignKey("IdEleccion")]
        public TtipoEleccion LTipoEleccion { get; set; }

    }
}
