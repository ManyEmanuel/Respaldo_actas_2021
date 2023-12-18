using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WebComputos.AccesoDatos.Data;
using WebComputos.AccesoDatos.Data.Repository;
using WebComputos.Models;
using WebComputos.Models.ViewModels;

namespace WebComputos.Areas.Admin.Controllers
{

    [Area("Admin")]
    public class CasillaDetController : Controller
    {
        private readonly IContenedorTrabajo _ctx;

        public CasillaDetController(IContenedorTrabajo ctx)
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
                CasillaDetVM CasillaDet = new CasillaDetVM()
                {
                    CasillaDet = new TCasillaDet(),
                    LSeccion = _ctx.Seccion.GetListaSeccion(),
                    LTipoCasilla = _ctx.TipoCasilla.GetListaTipoCasilla()
                };
            return View(CasillaDet);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(CasillaDetVM Casilla)
        {
            if (ModelState.IsValid)
            {
                _ctx.CasillaDet.Add(Casilla.CasillaDet);
                _ctx.Save();
                return RedirectToAction(nameof(Index));
            }

            return View(Casilla);
        }

        [HttpGet]
        public IActionResult Edit(int? id)
        {
            CasillaDetVM CasillaDet = new CasillaDetVM()
            {
                CasillaDet = new TCasillaDet(),
                LSeccion = _ctx.Seccion.GetListaSeccion(),
                LTipoCasilla = _ctx.TipoCasilla.GetListaTipoCasilla()
            };

            if (id != null)
            {
                CasillaDet.CasillaDet = _ctx.CasillaDet.Get((int)id);
                return View(CasillaDet);
            }

            return NotFound();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(CasillaDetVM Casilla)
        {
            if (ModelState.IsValid)
            {
                _ctx.CasillaDet.Update(Casilla.CasillaDet);
                _ctx.Save();
                return RedirectToAction(nameof(Index));
            }

            return View();
        }

        #region APICALLS

        [HttpGet]
        public IActionResult GetAll()
        {
            return Json(new { data = _ctx.CasillaDet.GetAll(includeProperties: "Lseccion,LTipocasilla") });
        }

        [HttpDelete]
        public IActionResult Delete(int id)
        {
            var CasillaDet = _ctx.CasillaDet.Get(id);
            if (CasillaDet == null)
            {
                return Json(new { success = false, message = "Error al eliminar el registro" });
            }
            _ctx.CasillaDet.Remove(CasillaDet);
            _ctx.Save();
            return Json(new { success = true, message = "Registro eliminado con éxito" });
        }

        #endregion
    }
}