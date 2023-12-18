using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Text;
using WebComputos.Models;

namespace WebComputos.AccesoDatos.Data.Repository
{
    public interface ICoalicionRepository: IRepositor<TCoalicion>
    {
        IEnumerable<SelectListItem> GetListaCoalicion();
        void Update(TCoalicion Coalicion);
    }
}
