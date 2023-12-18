using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Text;
using WebComputos.Models;

namespace WebComputos.AccesoDatos.Data.Repository
{
    public interface ICandidatoRepository : IRepositor<TCandidato>
    {
        IEnumerable<SelectListItem> GetListaCandidato();
        void Update(TCandidato Candidato);
    }
}
