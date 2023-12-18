using System;
using System.Collections.Generic;
using System.Text;
using WebComputos.Models;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace WebComputos.AccesoDatos.Data.Repository
{
    public interface  IResultadosActasRepository : IRepositor<TResultadosActas>
    {
        IEnumerable<SelectListItem> GetListasResultados();
    }
}
