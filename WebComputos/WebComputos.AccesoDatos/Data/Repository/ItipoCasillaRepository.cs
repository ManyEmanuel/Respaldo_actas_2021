using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Text;
using WebComputos.Models;

namespace WebComputos.AccesoDatos.Data.Repository
{
    public interface ItipoCasillaRepository : IRepositor<TtipoCasilla> 
    {

        IEnumerable<SelectListItem> GetListaTipoCasilla();

        void Update(TtipoCasilla TipoCasilla);
    }
}
