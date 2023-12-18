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
    public class TiposEleccionController : Controller
    {
        private readonly IContenedorTrabajo _ctx;

        public TiposEleccionController(IContenedorTrabajo ctx)
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
        public IActionResult Create(TtipoEleccion Tipo)
        {
            if (ModelState.IsValid)
            {
                _ctx.TipoEleccion.Add(Tipo);
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
                TtipoEleccion tipo = new TtipoEleccion();
                tipo = _ctx.TipoEleccion.Get((int)id);
                return View(tipo);
            }

            return NotFound();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(TtipoEleccion Tipo)
        {
            if (ModelState.IsValid)
            {
                _ctx.TipoEleccion.Update(Tipo);
                _ctx.Save();
                return RedirectToAction(nameof(Index));

            }
            return View(Tipo);
        }

        [HttpDelete]
        public IActionResult Delete(int id)
        {
            var Tipoeleccion = _ctx.TipoEleccion.Get(id);
            if (Tipoeleccion == null)
            {
                return Json(new { success = false, message = "Error al eliminar el registro" });
            }
            _ctx.TipoEleccion.Remove(Tipoeleccion);
            _ctx.Save();
            return Json(new { success = true, message = "Registro eliminado con éxito" });
        }

        #region APICALLS
        [HttpGet]
        public IActionResult GetAll()
        {
            return Json(new { data = _ctx.TipoEleccion.GetAll() });
        }
        #endregion

    }
}