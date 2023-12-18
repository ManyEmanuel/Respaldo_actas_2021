using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Text;

namespace WebComputos.Models.ViewModels
{
    public class SeccionVM
    {
        public TSeccion Seccion { get; set; }
        public IEnumerable<SelectListItem> LDistrito { get; set; }
        public IEnumerable<SelectListItem> LMunicipio { get; set; }
        public IEnumerable<SelectListItem> LDemarcacion { get; set; }

    }
}
