using System;
using System.Collections.Generic;
using System.Text;

namespace WebComputos.Models.ViewModels
{
    public class MenuDinamicoVM
    {
        public IEnumerable<TDemarcacion> LDemarcaciones;
        public IEnumerable<TSeccion> Lsecciones;
        public List<int?> LDistrito;
    }
}
