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
    public class CandidatosController : Controller
    {

        private readonly IContenedorTrabajo _ctx;
        public CandidatosController(IContenedorTrabajo ctx)
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
            CandidatosVM CandVM = new CandidatosVM()
            {
                Candidato = new Models.TCandidato(),
                LCoalicion = _ctx.Coalicion.GetListaCoalicion(),
                LDemarcacion = _ctx.Demarcacion.GetListaDemarcacion(),
                LDistrito = _ctx.Distrito.GetListaDistrito(),
                Lmunicipio = _ctx.Municipio.GetListaMunicipio(),
                LPartido = _ctx.Partido.GetListPartidos(),
                LTipoEleccion = _ctx.TipoEleccion.GetListaTipoEleccion(),
            };
            return View(CandVM);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(CandidatosVM CandVM)
        {
            if (ModelState.IsValid)
            {
                _ctx.Candidato.Add(CandVM.Candidato);
                _ctx.Save();
                return RedirectToAction(nameof(Index));
            }
            return View();
        }

        [HttpGet]
        public IActionResult Edit(int? id)
        {
            CandidatosVM CandVM = new CandidatosVM()
            {
                Candidato = new Models.TCandidato(),
                LCoalicion = _ctx.Coalicion.GetListaCoalicion(),
                LDemarcacion = _ctx.Demarcacion.GetListaDemarcacion(),
                LDistrito = _ctx.Distrito.GetListaDistrito(),
                Lmunicipio = _ctx.Municipio.GetListaMunicipio(),
                LPartido = _ctx.Partido.GetListPartidos(),
                LTipoEleccion = _ctx.TipoEleccion.GetListaTipoEleccion(),
            };

            if (id != null)
            {
                CandVM.Candidato = _ctx.Candidato.Get(id.GetValueOrDefault());
                return View(CandVM);
            }
            return NotFound();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(CandidatosVM CandVM)
        {
            if (ModelState.IsValid)
            {
                _ctx.Candidato.Update(CandVM.Candidato);
                _ctx.Save();
                return RedirectToAction(nameof(Index));
            }
            return View(CandVM);
        }

        [HttpDelete]
        public IActionResult Delete(int id)
        {
            var Candidato = _ctx.Candidato.Get(id);

            if (Candidato == null)
            {
                return Json(new { success = false, message = "Error al eliminar el registro" });
            }

            _ctx.Candidato.Remove(Candidato);
            _ctx.Save();
            return Json(new { success = true, message = "Registro eliminado con éxito" });
        }
    }
}