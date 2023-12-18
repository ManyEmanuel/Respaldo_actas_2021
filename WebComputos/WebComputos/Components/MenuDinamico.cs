using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using WebComputos.AccesoDatos.Data.Repository;
using WebComputos.Models;
using WebComputos.Models.ViewModels;

namespace WebComputos.Components
{
    public class MenuDinamico : ViewComponent
    {
        private readonly IContenedorTrabajo _ctx;
        private readonly UserManager<ApplicationUser> _userManager;

        public MenuDinamico(IContenedorTrabajo ctx, UserManager<ApplicationUser> userManager)
        {
            _ctx = ctx;
            _userManager = userManager;
        }

        public IViewComponentResult Invoke()
        {
            var Usuario = _userManager.GetUserId(UserClaimsPrincipal);
            var CurrentUser = _ctx.ApplicationUser.GetFirstOrDefault(x => x.Id == Usuario);
            var Oficina = _ctx.Oficina.Get(CurrentUser.IdOficina);

            MenuDinamicoVM Munu = new MenuDinamicoVM()
            {
                LDemarcaciones = _ctx.Demarcacion.GetAll(x=> x.Municipio == Oficina.Municipio),
                Lsecciones = _ctx.Seccion.GetAll(x=> x.Municipio == Oficina.Municipio)
            };
            return View(Munu);
        }
    
    }
}
