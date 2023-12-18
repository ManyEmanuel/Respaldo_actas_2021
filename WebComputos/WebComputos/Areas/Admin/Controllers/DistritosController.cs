using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WebComputos.AccesoDatos.Data.Repository;

namespace WebComputos.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class DistritosController : Controller
    {
        private readonly IContenedorTrabajo _ctx;

        public DistritosController(IContenedorTrabajo ctx)
        {
            _ctx = ctx;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult Detalles(int id)
        {
            var distrito = _ctx.Distrito.Get(id);
            if (distrito == null)
            {
                return NotFound();
            }

            return View(distrito);
        }


        #region APICALLS

        [HttpGet]
        public IActionResult GetAll()
        {
            return Json(new { data = _ctx.Distrito.GetAll() });
        }

        #endregion
    }
}