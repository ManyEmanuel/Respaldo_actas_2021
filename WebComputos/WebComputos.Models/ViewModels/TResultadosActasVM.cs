using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace WebComputos.Models.ViewModels
{
    public class TResultadosActasVM
    {
        public TResultadosActas Resultados { get; set; }
        //public TActas Actas { get; set; }
        public TPartidos Partidos { get; set; }
        public TCoalicion coalicion { get; set; }
        public Combinaciones combinaciones { get; set; }
        public IEnumerable<SelectListItem> LActa { get; set; }
    }
}
