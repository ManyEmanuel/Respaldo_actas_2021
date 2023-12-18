using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Text;
using WebComputos.Models;

namespace WebComputos.AccesoDatos.Data.Repository
{
    public interface IDistritoReporitory: IRepositor<TDistrito>
    {
        IEnumerable<SelectListItem> GetListaDistrito();

        void Update(TDistrito distrito);

        List<int?> DistritoBySeccion(int idmun);


    }
}
