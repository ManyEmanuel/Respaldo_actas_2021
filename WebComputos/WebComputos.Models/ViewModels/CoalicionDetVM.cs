using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Text;

namespace WebComputos.Models.ViewModels
{
    public class CoalicionDetVM
    {
        public TCoalicionDet Coalicion { get; set; }
        public IEnumerable<SelectListItem> LCoalicion { get; set; }
        public IEnumerable<SelectListItem> LPartido { get; set; }
    }
}
