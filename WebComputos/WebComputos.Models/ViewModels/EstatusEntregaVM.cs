using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace WebComputos.Models.ViewModels
{
    public class EstatusEntregaVM
    {
        public EstatusEntrega EstatusEntrega { get; set; }
        public IEnumerable<SelectListItem> LCasillaDet { get; set; }
        public IEnumerable<SelectListItem> LTipoEleccion { get; set; }
    }
}
