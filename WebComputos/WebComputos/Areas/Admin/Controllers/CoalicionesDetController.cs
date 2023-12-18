using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WebComputos.AccesoDatos.Data.Repository;
using WebComputos.Models.ViewModels;
using WebComputos.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using WebComputos.AccesoDatos.Data;


namespace WebComputos.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class CoalicionesDetController : Controller
    {
        private readonly IContenedorTrabajo _ctx;

        public CoalicionesDetController(IContenedorTrabajo ctx)
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
            CoalicionDetVM CoaVM = new CoalicionDetVM()
            {
                Coalicion = new TCoalicionDet(),
                LCoalicion = _ctx.Coalicion.GetListaCoalicion(),
                LPartido = _ctx.Partido.GetListPartidos()
            };
            return View(CoaVM);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(CoalicionDetVM CoaVM)
        {
            if (ModelState.IsValid)
            {
                _ctx.CoalicionDet.Add(CoaVM.Coalicion);
                _ctx.Save();
                return RedirectToAction(nameof(Index));
            }

            return View();
        }

        [HttpGet]
        public IActionResult Edit(int? id)
        {
            CoalicionDetVM CoaVM = new CoalicionDetVM()
            {
                Coalicion = new TCoalicionDet(),
                LCoalicion = _ctx.Coalicion.GetListaCoalicion(),
                LPartido = _ctx.Partido.GetListPartidos()

            };
            if (id != null)
            {
                CoaVM.Coalicion = _ctx.CoalicionDet.Get((int)id);
                return View(CoaVM);
            }
            return NotFound();

        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(CoalicionDetVM coaVM)
        {
            if (ModelState.IsValid)
            {
                _ctx.CoalicionDet.Update(coaVM.Coalicion);
                _ctx.Save();
                return RedirectToAction(nameof(Index));
            }
            return View();
        }


        #region APICALLS

        [HttpGet]
        public IActionResult GetAll()
        {
            return Json(new { data = _ctx.CoalicionDet.GetAll(includeProperties: "LPartido,LCoalicion") });
        }

        [HttpDelete]
        public IActionResult Delete(int id)
        {
            var coaliciond = _ctx.CoalicionDet.Get(id);
            if (coaliciond == null)
            {
                return Json(new { success = false, message = "Error al eliminar el registro" });
            }
            _ctx.CoalicionDet.Remove(coaliciond);
            _ctx.Save();
            return Json(new { success = true, message = "Registro eliminado con éxito" });
        }

        #endregion

    }
}