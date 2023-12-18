using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Text;
using WebComputos.Models;

namespace WebComputos.AccesoDatos.Data.Repository
{
    public interface IPartidoRepository: IRepositor<TPartidos> 
    {
        IEnumerable<SelectListItem> GetListPartidos();
        void Update(TPartidos Partido);
    }
}
