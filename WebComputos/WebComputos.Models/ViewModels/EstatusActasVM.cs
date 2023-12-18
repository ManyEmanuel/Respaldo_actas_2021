using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Text;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace WebComputos.Models.ViewModels
{
    public class EstatusActasVM
    {
        public EstatusActa EstatuActa { get; set; }
        public IEnumerable<SelectListItem> LestatusActa { get; set; }
    }
}
