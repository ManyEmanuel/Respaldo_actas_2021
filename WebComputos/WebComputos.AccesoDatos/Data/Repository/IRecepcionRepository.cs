using System;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;
using System.Text;
using WebComputos.Models;

namespace WebComputos.AccesoDatos.Data.Repository
{
    public interface IRecepcionRepository : IRepositor<TRecepcionPaquetes>
    {
        IEnumerable<SelectListItem> GetListaRecepcion();

        IEnumerable<ElementosListas> GetListaPaquetesByMun(int mun);


    }
}
