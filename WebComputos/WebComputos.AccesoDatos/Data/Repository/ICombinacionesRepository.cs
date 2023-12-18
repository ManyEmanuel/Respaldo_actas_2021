using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Text;
using WebComputos.Models;

namespace WebComputos.AccesoDatos.Data.Repository
{
    public interface ICombinacionesRepository :IRepositor<Combinaciones>
    {
        IEnumerable<SelectListItem> GetListaCombinaciones();

        void Update(Combinaciones combi);
    }
}
