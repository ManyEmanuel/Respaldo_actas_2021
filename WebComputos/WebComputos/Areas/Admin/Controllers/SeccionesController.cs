using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WebComputos.AccesoDatos.Data.Repository;
using WebComputos.Models;
using WebComputos.Models.ViewModels;

namespace WebComputos.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class SeccionesController : Controller
    {
        private readonly IContenedorTrabajo _ctx;

        public SeccionesController(IContenedorTrabajo ctx)
        {
            _ctx = ctx;
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult Create()
        {
            SeccionVM Seccion = new SeccionVM()
            {
                Seccion = new TSeccion(),
                LDemarcacion = _ctx.Demarcacion.GetListaDemarcacion(),
                LDistrito = _ctx.Distrito.GetListaDistrito(),
                LMunicipio = _ctx.Municipio.GetListaMunicipio()
            };

            return View(Seccion);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(SeccionVM SeccionVm)
        {
            if (ModelState.IsValid)
            {
                _ctx.Seccion.Add(SeccionVm.Seccion);
                _ctx.Save();
                return RedirectToAction(nameof(Index));
            }
            return View(SeccionVm);
        }

        [HttpGet]
        public IActionResult Edit(int? id)
        {
            SeccionVM seccion = new SeccionVM()
            {
                Seccion = new TSeccion(),
                LDemarcacion = _ctx.Demarcacion.GetListaDemarcacion(),
                LDistrito = _ctx.Distrito.GetListaDistrito(),
                LMunicipio = _ctx.Municipio.GetListaMunicipio(),

            };
            if(id != null)
            {
                seccion.Seccion = _ctx.Seccion.Get(id.GetValueOrDefault());
            }

            return View(seccion);
        }

        [HttpDelete]
        public IActionResult Delete(int id)
        {
            var Seccion = _ctx.Seccion.Get(id);
            if (Seccion == null)
            {
                return Json(new { success = false, message = "error al eliminar sección" });
            }
            _ctx.Seccion.Remove(Seccion);
            _ctx.Save();
            return Json(new { success = true, message = "Sección eliminada con éxito" });
        }
        

        #region APICALLS

        [HttpGet]
        public IActionResult GetAll()
        {
            return Json(new { data = _ctx.Seccion.GetAll(includeProperties: "Ldistrito,Ldemarcacion,Lmunicipio") });
        }

        #endregion

    }
}