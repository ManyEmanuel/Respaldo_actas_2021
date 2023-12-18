using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace WebComputos.Models.ViewModels
{
    public class RecepcionDetalleVM
    {
        public RecepcionDetalle  RecepcionDetalle{ get; set;}
        public TRecepcionPaquetes RecPaquetes { get; set; }
        public TtipoEleccion TipoEleccion { get; set; }

    }
}
