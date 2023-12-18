using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace WebComputos.Models.ViewModels
{
    public class ActasVM
    {
        public TActas Actas { get; set; }
        public TRecepcionPaquetes RecPaquetes { get; set; }
        public TResultadosActas ResActas { get; set; }
        public IEnumerable<SelectListItem> LRecepcion { get; set; }
        public IEnumerable<SelectListItem>LEstatusActa { get; set; }
        public EstatusActa Estacta { get; set; }
        public IEnumerable<SelectListItem> LSeccion { get; set; }
        public IEnumerable<SelectListItem> LSeccionPaq { get; set; }
        public IEnumerable<SelectListItem> LSeccionGob { get; set; }
        public IEnumerable<SelectListItem> LSeccionPys { get; set; }
        public IEnumerable<SelectListItem> LSeccionDip { get; set; }
        public IEnumerable<SelectListItem> LSeccionReg { get; set; }





    }
}
