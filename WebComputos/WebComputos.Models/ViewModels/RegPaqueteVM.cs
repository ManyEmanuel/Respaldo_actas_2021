using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Mvc.Rendering;


namespace WebComputos.Models.ViewModels
{
    public class RegPaqueteVM
    {
        
        public TCasillaDet CasillaDet { get; set; }

        public int Value { get; set; }
        public TRecepcionPaquetes RecPaquetes { get; set; }

        public TSeccion Seccion { get; set; }

        public IEnumerable<TRecepcionPaquetes> LRecepcion { get; set; }
        public IEnumerable<SelectListItem> LSeccion { get; set; }
        public IEnumerable<SelectListItem> LSeccionPaq { get; set; }
        public IEnumerable<SelectListItem> LTipoCasilla { get; set; }

    }
}
