using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WebComputos.Models;
using WebComputos.AccesoDatos.Data.Repository;
using WebComputos.Models.ViewModels;

namespace WebComputos.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class DemarcacionesController : Controller
    {
        private readonly IContenedorTrabajo _ctx;

        public DemarcacionesController(IContenedorTrabajo ctx)
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
            DemarcacionVM DemVM = new DemarcacionVM()
            {
                Demarcacion = new WebComputos.Models.TDemarcacion(),
                LMunicipio = _ctx.Municipio.GetListaMunicipio()
            };
            return View(DemVM);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(DemarcacionVM dmVM)
        {
            if (ModelState.IsValid)
            {
                _ctx.Demarcacion.Add(dmVM.Demarcacion);
                _ctx.Save();
                return RedirectToAction(nameof(Index));
            }

            return View(dmVM);
        }

        [HttpGet]
        public IActionResult Edit(int? id)
        {
            DemarcacionVM DemVM = new DemarcacionVM()
            {
                Demarcacion = new TDemarcacion(),
                LMunicipio = _ctx.Municipio.GetListaMunicipio()
            };

            if (id != null)
            {
                DemVM.Demarcacion = _ctx.Demarcacion.Get(id.GetValueOrDefault());
            }

            return View(DemVM);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(DemarcacionVM Dvm)
        {
            if (ModelState.IsValid)
            {
                _ctx.Demarcacion.Update(Dvm.Demarcacion);
                _ctx.Save();
                return RedirectToAction(nameof(Index));
            }

            return View();
        }

        [HttpDelete]
        public IActionResult Delete(int id)
        {
            var Demarcacion = _ctx.Demarcacion.Get(id);
            if (Demarcacion == null)
            {
                return Json(new { success = false, message = "error al eliminar registro" });
            }
            _ctx.Demarcacion.Remove(Demarcacion);
            _ctx.Save();
            return Json(new { success = true, message = "registro eliminado con éxito" });
        }

        


        #region APICALLS

        [HttpGet]
        public IActionResult GetAll()
        {
            return Json(new { data = _ctx.Demarcacion.GetAll(includeProperties: "Municipios") });
        }

        #endregion
    }
}