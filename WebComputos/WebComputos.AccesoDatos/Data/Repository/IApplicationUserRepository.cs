using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Text;
using WebComputos.Models;

namespace WebComputos.AccesoDatos.Data.Repository
{
    public interface IApplicationUserRepository : IRepositor<ApplicationUser>
    {
        IEnumerable<SelectListItem> GetListaUsuarios();
        void Update(ApplicationUser user);
    }
}
