using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using WebComputos.AccesoDatos.Data.Repository;
using WebComputos.Models;

namespace WebComputos.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class PartidosController : Controller
    {

        private readonly IContenedorTrabajo _ctx;
        private readonly IWebHostEnvironment _Host;

        public PartidosController(IContenedorTrabajo ctx, IWebHostEnvironment Host)
        {
            _ctx = ctx;
            _Host = Host;
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
        public IActionResult Create(TPartidos partido)
        {
            if (ModelState.IsValid)
            {

                string rutaPrincipal = _Host.WebRootPath;
                var archivos = HttpContext.Request.Form.Files;
                

                if (partido.IdPartido != 0)
                {
                    return View();
                }
                if (archivos.Count() > 0)
                {
                    string NombreLogo = Guid.NewGuid().ToString();
                    var subidas = Path.Combine(rutaPrincipal, @"Imagenes\Logos");
                    var extension = Path.GetExtension(archivos[0].FileName);

                    using (var filestream = new FileStream(Path.Combine(subidas, NombreLogo + extension), FileMode.Create))
                    {
                        archivos[0].CopyTo(filestream);
                    }
                    partido.LogoURL = @"\Imagenes\Logos\" + NombreLogo + extension;
                }

              
             
                _ctx.Partido.Add(partido);
                _ctx.Save();
                return RedirectToAction(nameof(Index));
            }

            return View(partido);
        }

        [HttpGet]
        public IActionResult Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var Partido = _ctx.Partido.Get((int)id);
            if (Partido == null)
            {
                return NotFound();
            }
            return View(Partido);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(TPartidos partido)
        {
            if (ModelState.IsValid)
            {
                string rutaPrincipal = _Host.WebRootPath;
                var archivos = HttpContext.Request.Form.Files;
                if (archivos.Count() > 0)
                {
                    var LogoBd = _ctx.Partido.Get(partido.IdPartido);
                    string NombreLogo = Guid.NewGuid().ToString();
                    var subidas = Path.Combine(rutaPrincipal, @"Imagenes\Logos");
                    var extension = Path.GetExtension(archivos[0].FileName);
                    if (LogoBd.LogoURL != null)
                    {
                        var rutaImagen = Path.Combine(rutaPrincipal, LogoBd.LogoURL.TrimStart('\\'));

                        if (System.IO.File.Exists(rutaImagen))
                        {
                            System.IO.File.Delete(rutaImagen);
                        }
                    }
                  

                    using (var filestream = new FileStream(Path.Combine(subidas, NombreLogo + extension), FileMode.Create))
                    {
                        archivos[0].CopyTo(filestream);
                    }
                    partido.LogoURL = @"\Imagenes\Logos\" + NombreLogo + extension;
                }
             

                _ctx.Partido.Update(partido);
                _ctx.Save();
                return RedirectToAction(nameof(Index));
            }
            return View(partido);
        }

        [HttpDelete]
        public IActionResult Delete(int id)
        {
            string rutaPrincipal = _Host.WebRootPath;
            var Partido = _ctx.Partido.Get(id);
            var rutaImagen = "";
            if(Partido.LogoURL != null)
            {
                rutaImagen= Path.Combine(rutaPrincipal, Partido.LogoURL.TrimStart('\\'));
                if (System.IO.File.Exists(rutaImagen))
                {
                    System.IO.File.Delete(rutaImagen);
                }
            }
            if (Partido == null)
            {
                return Json(new { success = false, message = "Error al eliminar el registro" });
            }
            _ctx.Partido.Remove(Partido);
            _ctx.Save();
            return Json(new { success = true, message = "Registro eliminado con éxito" });
        }

        #region APICALLS
        [HttpGet]
        public IActionResult GetAll()
        {
            return Json(new { data = _ctx.Partido.GetAll() });
        }
        #endregion
    }
}