using System;
using System.Collections.Generic;
using System.Text;
using WebComputos.Models;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace WebComputos.AccesoDatos.Data.Repository
{
    public interface IActasRepository : IRepositor<TActas>
    {
        IEnumerable<SelectListItem> GetListaActas();
    }
}
