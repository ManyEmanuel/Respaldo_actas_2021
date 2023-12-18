using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Text;
using WebComputos.Models;

namespace WebComputos.AccesoDatos.Data.Repository
{
    public interface ICatEleccionRepository :IRepositor<TtipoEleccion>
    {
        IEnumerable<SelectListItem> GetListaTipoEleccion();

        void Update(TtipoEleccion TipoEleccion);
    }
}
