using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Text;
using WebComputos.Models;

namespace WebComputos.AccesoDatos.Data.Repository
{
    public interface IMunicipiosRepository :IRepositor<TMunicipio>
    {
        IEnumerable<SelectListItem> GetListaMunicipio();

        void Update(TMunicipio municipio);
    }
}
