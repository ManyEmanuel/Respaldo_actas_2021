using System;
using System.Collections.Generic;
using System.Text;
using WebComputos.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using WebComputos.Models;

namespace WebComputos.AccesoDatos.Data.Repository
{
    public interface ICausalesRepository : IRepositor<Causales>
    {
        IEnumerable<ElementosListas> GetListaGobernador(int mun);
        IEnumerable<ElementosListas> GetListaPys(int mun);
        IEnumerable<ElementosListas> GetListaDip(int mun);
        IEnumerable<ElementosListas> GetListaReg(int mun);

    }
}
