using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WebComputos.AccesoDatos.Data.Repository;

namespace WebComputos.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class MunicipiosController : Controller
    {
        private readonly IContenedorTrabajo _ctx;
        public MunicipiosController(IContenedorTrabajo ctx)
        {
            _ctx = ctx;
        }
        public IActionResult Index()
        {
            return View();
        }


        #region Llamadas a la api
        [HttpGet]
        public IActionResult GetAll()
        {
            return Json(new { data = _ctx.Municipio.GetAll() });
        }

        #endregion

    }
}