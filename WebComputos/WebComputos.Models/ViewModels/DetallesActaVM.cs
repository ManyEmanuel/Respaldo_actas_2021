using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Mvc.Rendering;


namespace WebComputos.Models.ViewModels
{
    public class DetallesActaVM
    {
        public DetallesActas DetallesActas { get; set; }
        public IEnumerable<SelectListItem> LdetalleActa { get; set; }

    }
}
