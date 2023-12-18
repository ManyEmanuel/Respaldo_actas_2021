using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Text;
using WebComputos.Models;

namespace WebComputos.AccesoDatos.Data.Repository
{
    public interface IcoalicionDetRepository : IRepositor<TCoalicionDet>
    {
        IEnumerable<SelectListItem> GetListaCoalicion();
        void Update(TCoalicionDet coaliciondet);
    }
}
