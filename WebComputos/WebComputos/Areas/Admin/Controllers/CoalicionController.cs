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
    public class CoalicionController : Controller
    {

        private readonly IContenedorTrabajo _ctx;
        private readonly IWebHostEnvironment _Host;
        public CoalicionController(IContenedorTrabajo ctx, IWebHostEnvironment Host)
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
        public IActionResult Create(TCoalicion Coalicion)
        {
            if (ModelState.IsValid)
            {
                string rutaPrincipal = _Host.WebRootPath;
                var archivos = HttpContext.Request.Form.Files;

                if (Coalicion.IdCoalicion != 0)
                {
                    return View();
                }
                if (archivos.Count() > 0)
                {
                    string NombreLogo = Guid.NewGuid().ToString();
                    var subidas = Path.Combine(rutaPrincipal, @"Imagenes\Logos");
                    var extension = Path.GetExtension(archivos[0].FileName);

                    using(var filestream = new FileStream(Path.Combine(subidas, NombreLogo + extension), FileMode.Create))
                    {
                        archivos[0].CopyTo(filestream);
                    }
                    Coalicion.Logo= @"\Imagenes\Logos\" + NombreLogo + extension;
                }

                _ctx.Coalicion.Add(Coalicion);
                _ctx.Save();
                return RedirectToAction(nameof(Index));
            }
            return View(Coalicion);
        }

        [HttpGet]
        public IActionResult Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var Coalicion = _ctx.Coalicion.Get((int)id);
            if (Coalicion == null)
            {
                return NotFound();
            }
            return View(Coalicion);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(TCoalicion coalicion)
        {
            if (ModelState.IsValid)
            {
                var Logo = "";
                string rutaPrincipal = _Host.WebRootPath;
                var archivos = HttpContext.Request.Form.Files;
                if (archivos.Count() > 0)
                {
                    var LogoBd = _ctx.Coalicion.Get(coalicion.IdCoalicion);
                    string NombreLogo = Guid.NewGuid().ToString();
                    var subidas = Path.Combine(rutaPrincipal, @"Imagenes\Logos");
                    var extension = Path.GetExtension(archivos[0].FileName);
                    if (LogoBd.Logo != null)
                    {
                        Logo = LogoBd.Logo;
                        var rutaImagen = Path.Combine(rutaPrincipal, LogoBd.Logo.TrimStart('\\'));

                        if (System.IO.File.Exists(rutaImagen))
                        {
                            System.IO.File.Delete(rutaImagen);
                        }
                    }


                    using (var filestream = new FileStream(Path.Combine(subidas, NombreLogo + extension), FileMode.Create))
                    {
                        archivos[0].CopyTo(filestream);
                    }
                    coalicion.Logo = @"\Imagenes\Logos\" + NombreLogo + extension;
                }
                coalicion.Logo = Logo;

                _ctx.Coalicion.Update(coalicion);
                _ctx.Save();
                return RedirectToAction(nameof(Index));
            }

            return View(coalicion);
        }

        [HttpDelete]
        public IActionResult Delete (int id)
        {
            string rutaPrincipal = _Host.WebRootPath;
            var Coalicion = _ctx.Coalicion.Get(id);
            var rutaImagen = "";
            if (Coalicion.Logo != null)
            {
                rutaImagen = Path.Combine(rutaPrincipal, Coalicion.Logo.TrimStart('\\'));
                if (System.IO.File.Exists(rutaImagen))
                {
                    System.IO.File.Delete(rutaImagen);
                }
            }
            if (Coalicion == null)
            {
                return Json(new { success = false, message = "Error al eliminar el registro" });
            }
            _ctx.Coalicion.Remove(Coalicion);
            _ctx.Save();
            return Json(new { success = true, message = "Registro eliminado con éxito" });
        }

        #region APICALLS
        [HttpGet]
        public IActionResult GetAll()
        {
            return Json(new { data = _ctx.Coalicion.GetAll() });
        }
        #endregion

    }
}