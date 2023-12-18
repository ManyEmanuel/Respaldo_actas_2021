using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace WebComputos.Models.ViewModels
{
    public class CausalesVM
    {
        public Causales Causales { get; set; }
        public TCasillaDet CasillaDet { get; set; }
        public IEnumerable<SelectListItem> LCasillaDet { get; set; }
        
    }
}
