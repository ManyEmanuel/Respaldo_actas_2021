using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Text;
using WebComputos.Models;

namespace WebComputos.AccesoDatos.Data.Repository
{
    public interface IOficina : IRepositor<TOficina>
    {
        IEnumerable<SelectListItem> GetListaOficina();
        void Update(TOficina Oficina);
    }
}