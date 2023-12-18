using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Text;
using WebComputos.Models;

namespace WebComputos.AccesoDatos.Data.Repository
{
    public interface ICasillaDetRepository: IRepositor<TCasillaDet>
    {
        IEnumerable<SelectListItem> GetListaTipoCasilla();
        void Update(TCasillaDet CasillaDet);
    }
}
