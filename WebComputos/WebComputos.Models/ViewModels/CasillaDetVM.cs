using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Text;

namespace WebComputos.Models.ViewModels
{
    public class CasillaDetVM
    {
        public TCasillaDet CasillaDet { get; set; }
        public IEnumerable<SelectListItem> LSeccion { get; set; }
        public IEnumerable<SelectListItem> LTipoCasilla { get; set; }
    }
}
