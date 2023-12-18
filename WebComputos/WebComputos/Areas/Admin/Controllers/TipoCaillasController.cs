using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WebComputos.AccesoDatos.Data.Repository;
using WebComputos.Models;

namespace WebComputos.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class TipoCaillasController : Controller
    {

        private readonly IContenedorTrabajo _ctx;
        public TipoCaillasController(IContenedorTrabajo ctx)
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
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(TtipoCasilla Tipo)
        {
            if (ModelState.IsValid)
            {
                _ctx.TipoCasilla.Add(Tipo);
                _ctx.Save();
                return RedirectToAction(nameof(Index));
            }

            return View(Tipo);
        }

        [HttpGet]
        public IActionResult Edit(int? id)
        {
            if (id != null)
            {
                TtipoCasilla Tipo = new TtipoCasilla();
                Tipo = _ctx.TipoCasilla.Get((int)id);
                return View(Tipo);
            }
            return NotFound();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(TtipoCasilla tipo)
        {
            if (ModelState.IsValid)
            {
                _ctx.TipoCasilla.Update(tipo);
                _ctx.Save();
                return RedirectToAction(nameof(Index));
            }
            return View(tipo);
        }

        [HttpDelete]
        public IActionResult Delete(int id)
        {
            var tipo = _ctx.TipoCasilla.Get(id);
            if (tipo == null)
            {
                return Json(new { success = false, message = "Error al eliminar el registro" });
            }
            _ctx.TipoCasilla.Remove(tipo);
            _ctx.Save();
            return Json(new { success = true, message = "Registro eliminado con éxito" });
        }



        #region APICALLS
        [HttpGet]
        public IActionResult GetAll()
        {
            return Json(new { data = _ctx.TipoCasilla.GetAll() });
        }
        #endregion
    }
}