using System;
using System.Collections.Generic;
using System.Text;

namespace WebComputos.Models.ViewModels
{
    public class ResultadosVM
    {
        public IEnumerable<TPartidos> LPArtidos { get; set; }
        public IEnumerable<Combinaciones> LCombinaciones { get; set; }
        public IEnumerable<TActas> LActas { get; set; }
        public IList<TResultadosActas> Resultado { get; set; }
        public int IdPartido { get; set; }
        public int IdCoalicion { get; set; }
        public int idCombinacion { get; set; }
        public int idIndependiente { get; set; }
        public int votos { get; set; }





    }
}
