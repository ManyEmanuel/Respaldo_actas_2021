using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Text;

namespace WebComputos.Models.ViewModels
{
    public class DemarcacionVM
    {
        public TDemarcacion Demarcacion { get; set; }
        public IEnumerable<SelectListItem> LMunicipio { get; set; }
    }
}
