using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Text;
using WebComputos.Models;

namespace WebComputos.AccesoDatos.Data.Repository
{
    public interface IDemarcacionRepository: IRepositor<TDemarcacion>
    {
        IEnumerable<SelectListItem> GetListaDemarcacion();

        void Update(TDemarcacion Demarcacion);
    }
}
