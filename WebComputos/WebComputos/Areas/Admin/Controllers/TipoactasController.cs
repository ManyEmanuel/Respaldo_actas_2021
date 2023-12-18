using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WebComputos.AccesoDatos.Data.Repository;
using WebComputos.Models.ViewModels;

namespace WebComputos.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class TipoactasController : Controller
    {
        private readonly IContenedorTrabajo _ctx;

        public TipoactasController(IContenedorTrabajo ctx)
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
            TipoActaVM ActaVM = new TipoActaVM()
            {
                TipoActa = new Models.TtipoActa(),
                LEleccion = _ctx.TipoEleccion.GetListaTipoEleccion()
            };
            return View(ActaVM);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(TipoActaVM Acta)
        {
            if (ModelState.IsValid)
            {
                _ctx.TipoActa.Add(Acta.TipoActa);
                _ctx.Save();
                return RedirectToAction(nameof(Index));
            }

            return View(Acta);
        }


        [HttpGet]
        public IActionResult Edit(int? id)
        {
           
            if(id==null)
            {
                return NotFound();
            }
            TipoActaVM ActaVM = new TipoActaVM()
            {
                TipoActa = new Models.TtipoActa(),
                LEleccion = _ctx.TipoEleccion.GetListaTipoEleccion()
            };
            ActaVM.TipoActa = _ctx.TipoActa.Get(id.GetValueOrDefault());
            return View(ActaVM);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(TipoActaVM modelo)
        {
            if (ModelState.IsValid)
            {
                _ctx.TipoActa.Update(modelo.TipoActa);
                _ctx.Save();
                return RedirectToAction(nameof(Index));
            }

            return View(modelo);
        }

        [HttpDelete]
        public IActionResult Delete(int id)
        {
            var tipoActa = _ctx.TipoActa.Get(id);
            if (tipoActa == null)
            {
                return Json(new { success = false, message = "error al eliminar Registro" });
            }
            _ctx.TipoActa.Remove(tipoActa);
            _ctx.Save();
            return Json(new { success = true, message = "Registro eliminado con éxito" });
        }

        #region APICALLS

        [HttpGet]
        public IActionResult GetAll()
        {
            return Json(new { data = _ctx.TipoActa.GetAll(includeProperties: "LTipoEleccion") });
        }

        #endregion

    }
}