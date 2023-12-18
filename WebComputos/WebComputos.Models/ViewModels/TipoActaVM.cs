using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Text;

namespace WebComputos.Models.ViewModels
{
    public class TipoActaVM
    {
        public TtipoActa TipoActa { get; set; }
        public IEnumerable<SelectListItem> LEleccion { get; set; }
    }
}
