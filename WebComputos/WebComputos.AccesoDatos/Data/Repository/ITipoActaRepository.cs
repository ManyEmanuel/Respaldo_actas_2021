using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Text;
using WebComputos.Models;

namespace WebComputos.AccesoDatos.Data.Repository
{
    public interface ITipoActaRepository: IRepositor<TtipoActa>
    {
        IEnumerable<SelectListItem> GetListaTipoActa();

        void Update(TtipoActa TipoActa);
    }
}
