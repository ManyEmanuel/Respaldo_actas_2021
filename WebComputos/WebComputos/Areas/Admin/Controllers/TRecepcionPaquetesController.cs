using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using WebComputos.AccesoDatos.Data;
using WebComputos.AccesoDatos.Data.Repository;
using WebComputos.Models;
using WebComputos.Models.ViewModels;

namespace WebComputos.Areas.Admin.Controllers
{
    
    [Area("Admin")]
    public class TRecepcionPaquetesController : Controller
    {
        private readonly IContenedorTrabajo _context;
        private ApplicationDbContext _db;
        private readonly UserManager<ApplicationUser> _UserManager;
        

        public TRecepcionPaquetesController(IContenedorTrabajo context, ApplicationDbContext db, UserManager<ApplicationUser>UserManager)
        {
            _context = context;
            _db = db;
            _UserManager = UserManager;
        }

        [HttpGet]
        public IActionResult Index()
        {
            var Id = _UserManager.GetUserId(User);
            var usuario = _db.ApplicationUser.Find(Id);
            var oficina = _db.TOficina.Find(usuario.IdOficina);
            var mun = _db.TMunicipio.Find(oficina.Municipio);
            decimal recibidos = _context.Recepcion.GetListaPaquetesByMun(mun.IdMunicipio).Count();
            decimal total = _context.Seccion.ListaCasillaByMunicipio(mun.IdMunicipio).Count();
            decimal t = (100 * recibidos) / total;
            decimal porcent = Math.Round(t, 2);

           
            ViewBag.Recibidos = recibidos;
            ViewBag.Total = total;
            ViewBag.Porcentaje = porcent;
            return View();
        }

        [HttpGet]
        public IActionResult CausalesGob()
        {
            var Id = _UserManager.GetUserId(User);
            var usuario = _db.ApplicationUser.Find(Id);
            var oficina = _db.TOficina.Find(usuario.IdOficina);
            var mun = _db.TMunicipio.Find(oficina.Municipio);
            var a = _context.Causales.GetListaGobernador(mun.IdMunicipio);
            decimal NumSeccion = _context.Seccion.ListaCasillaByMunicipio(mun.IdMunicipio).Count();
            decimal total = a.Count();
            decimal causal = a.Where(x => x.numcau != 0).Count();
            decimal t = (100 * total) / NumSeccion;
            decimal porcent = Math.Round(t, 2);
            if (causal == 0)
            {
                ViewBag.Causal = causal;
                ViewBag.Porcentaje = 0;
                ViewBag.Secciones = NumSeccion;
                ViewBag.Capturados = total;
                ViewBag.Cotejo = total - causal;
                ViewBag.CapturaPorcent = porcent;
            }
            else
            {
                decimal d = (100 * causal) / total;
                decimal porcentaje = Math.Round(d, 2);
                ViewBag.Causal = causal;
                ViewBag.Porcentaje = porcentaje;
                ViewBag.Secciones = NumSeccion;
                ViewBag.Capturados = total;
                ViewBag.CapturaPorcent = porcent;
                ViewBag.Cotejo = total - causal;
            }
            
            return View();
        }
        [HttpGet]
        public IActionResult CausalesPys()
        {
            var Id = _UserManager.GetUserId(User);
            var usuario = _db.ApplicationUser.Find(Id);
            var oficina = _db.TOficina.Find(usuario.IdOficina);
            var mun = _db.TMunicipio.Find(oficina.Municipio);
            var a = _context.Causales.GetListaPys(mun.IdMunicipio);
            int NumSeccion = _context.Seccion.ListaCasillaByMunicipio(mun.IdMunicipio).Count();
            decimal total = a.Count();
            decimal causal = a.Where(x => x.numcau != 0).Count();
            decimal t = (100 * total) / NumSeccion;
            decimal porcent = Math.Round(t, 2);
            if (causal == 0)
            {
                ViewBag.Causal = causal;
                ViewBag.Porcentaje = 0;
                ViewBag.Secciones = NumSeccion;
                ViewBag.Capturados = total;
                ViewBag.CapturaPorcent = porcent;
                ViewBag.Cotejo = total - causal;
                
            }
            else
            {
                decimal d = (100 * causal) / total;
                decimal porcentaje = Math.Round(d, 2);
                
                ViewBag.Causal = causal;
                ViewBag.Porcentaje = porcentaje;
                ViewBag.Secciones = NumSeccion;
                ViewBag.Capturados = total;
                ViewBag.CapturaPorcent = porcent;
                ViewBag.Cotejo = total - causal;
            }
            return View();
        }
        [HttpGet]
        public IActionResult CausalesDip(int id)
        {
            var Id = _UserManager.GetUserId(User);
            var usuario = _db.ApplicationUser.Find(Id);
            var oficina = _db.TOficina.Find(usuario.IdOficina);
            var mun = _db.TMunicipio.Find(oficina.Municipio);
            var a = _context.Causales.GetListaDip(mun.IdMunicipio);
            var b = a.Where(x => x.Distrito == id);
            int NumSeccion = _context.Seccion.ListaCasillaByDistrito(mun.IdMunicipio, id).Count();
            decimal total = b.Count();
            decimal causal = b.Where(x => x.numcau != 0).Count();
            decimal t = (100 * total) / NumSeccion;
            decimal porcent = Math.Round(t, 2);
            if (causal == 0)
            {
                ViewBag.Causal = causal;
                ViewBag.Porcentaje = 0;
                ViewBag.Secciones = NumSeccion;
                ViewBag.Capturados = total;
                ViewBag.CapturaPorcent = porcent;
                ViewBag.Cotejo = total - causal;
            }
            else
            {
                decimal d = (100 * causal) / total;
                decimal porcentaje = Math.Round(d, 2);
                ViewBag.Causal = causal;
                ViewBag.Porcentaje = porcentaje;
                ViewBag.Secciones = NumSeccion;
                ViewBag.Capturados = total;
                ViewBag.CapturaPorcent = porcent;
                ViewBag.Cotejo = total - causal;
            }
            ViewBag.Id = id;
            return View();
        }
        [HttpGet]
        public IActionResult CausalesReg(int id)
        {
            var Id = _UserManager.GetUserId(User);
            var usuario = _db.ApplicationUser.Find(Id);
            var oficina = _db.TOficina.Find(usuario.IdOficina);
            var mun = _db.TMunicipio.Find(oficina.Municipio);
            var a = _context.Causales.GetListaReg(mun.IdMunicipio);
            var b = a.Where(x => x.Demarcacion == id);
            int NumSeccion = _context.Seccion.ListaCasillaByDemarcacion(mun.IdMunicipio, id).Count();
            decimal total = b.Count();
            decimal causal = b.Where(x => x.numcau != 0).Count();
            decimal t = (100 * total) / NumSeccion;
            decimal porcent = Math.Round(t, 2);
            if (causal == 0)
            {
                ViewBag.Causal = causal;
                ViewBag.Porcentaje = 0;
                ViewBag.Secciones = NumSeccion;
                ViewBag.Capturados = total;
                ViewBag.CapturaPorcent = porcent;
                ViewBag.Cotejo = total - causal;
            }
            else
            {
                decimal d = (100 * causal) / total;
                decimal porcentaje = Math.Round(d, 2);
                ViewBag.Causal = causal;
                ViewBag.Porcentaje = porcentaje;
                ViewBag.Secciones = NumSeccion;
                ViewBag.Capturados = total;
                ViewBag.CapturaPorcent = porcent;
                ViewBag.Cotejo = total - causal;
            }
            ViewBag.Id = id;
            return View();
        }


        // GET: Admin/TRecepcionPaquetes/Create
        [HttpGet]
        public IActionResult Create()
        {
            var Id = _UserManager.GetUserId(User);
            var usuario = _db.ApplicationUser.Find(Id);
            var oficina = _db.TOficina.Find(usuario.IdOficina);
            var mun = _db.TMunicipio.Find(oficina.Municipio);

            RegPaqueteVM Paq = new RegPaqueteVM()
            {
                RecPaquetes = new TRecepcionPaquetes(),
                LSeccionPaq = _context.Seccion.ListaRecepcionByMunicipio(mun.IdMunicipio),
                LTipoCasilla = _context.TipoCasilla.GetListaTipoCasilla(),

            };


            return View(Paq);
        }

        public JsonResult Casillaid(int id)
        {
            var Id = _UserManager.GetUserId(User);
            var usuario = _db.ApplicationUser.Find(Id);
            var oficina = _db.TOficina.Find(usuario.IdOficina);
            var mun = _db.TMunicipio.Find(oficina.Municipio);
            List<ElementoJsonIntKey> lst = new List<ElementoJsonIntKey>();
            lst = (from d in _db.TtipoCasilla
                   join p in _db.TCasillaDet on d.IdTipoCasilla equals p.TipoCasilla
                   join f in _db.TSeccion on p.Seccion equals f.idSeccion
                   where p.Seccion == id && p.Activo == true && p.Capturado == false  && f.Municipio == mun.IdMunicipio
                   select new ElementoJsonIntKey
                   {
                       value = p.IdCasillaDet,
                       text = p.Nombre
                   }).OrderBy(x=> x.value).ToList();



            // lst.Insert(0, new ElementoJsonIntKey { value = 0, text = "Selecciona tipo de casilla" });
            return Json(new SelectList(lst, "value", "text"));
            
        }

        /*public JsonResult DetalleId(int id, int ids, string tex)
        {
           List<ElementoJsonIntKey> lst2 = new List<ElementoJsonIntKey>();
            lst2 = (from p in _db.TCasillaDet
                    join d in _db.TtipoCasilla on p.TipoCasilla equals d.IdTipoCasilla
                    where p.TipoCasilla == ids && p.Seccion == id && p.Nombre == tex
                    //&& p.NoCasilla == num
                    select new ElementoJsonIntKey
                    {
                        value1 = p.IdCasillaDet,
                        text1= p.IdCasillaDet.ToString()
                    }).ToList();
            // lst2.Insert(0, new ElementoJsonIntKey { value = 0, text = "Selecciona tipo de casilla" });
            return Json(new SelectList(lst2, "value1", "text1"));
        }*/

        public JsonResult Cambiar(int id)
        {
            var Cap = (from c in _db.TCasillaDet
                       where c.IdCasillaDet == id
                       select c).FirstOrDefault();
            Cap.Capturado = true;
            _db.SaveChanges();
            return Json(new { data = Cap });
        }

        [HttpGet]

        public JsonResult CargarDa()
        {
            var Id = _UserManager.GetUserId(User);
            var usuario = _db.ApplicationUser.Find(Id);
            var oficina = _db.TOficina.Find(usuario.IdOficina);
            var mun = _db.TMunicipio.Find(oficina.Municipio);
            var a = _context.Recepcion.GetListaPaquetesByMun(mun.IdMunicipio);
           
            // lst2.Insert(0, new ElementoJsonIntKey { value = 0, text = "Selecciona tipo de casilla" });
            return Json(new { data = a});
        }

        [HttpPost]
        [ValidateAntiForgeryToken]

        public IActionResult Create(RegPaqueteVM regPaqueteVM)
        {
            if (ModelState.IsValid)
            {
                _context.Recepcion.Add(regPaqueteVM.RecPaquetes);
                _context.Save();
                int id = regPaqueteVM.RecPaquetes.IdCasillaDet;
                int cau = Int32.Parse(regPaqueteVM.RecPaquetes.Observaciones);
                RegistroPaq(id);
                RegistroCau(id, cau);
                return RedirectToAction(nameof(Index));
                
            }
            return View(regPaqueteVM);
        }

        public IActionResult RegistroPaq (int id)
        {
            var Paq = _db.EstatusEntregas.Where(x => x.IdCasillaDet == id).FirstOrDefault();
            if(Paq.Paquetes == "No")
            {
                Paq.Paquetes = "Si";
                _db.SaveChanges();
            }
            return View();
        }

        public IActionResult RegistroCau(int id, int ca)
        {
            var cau = _db.Causales.Where(x => x.IdCasillaDet == id).ToList();
            Causales cles;
            if(cau.Count != 0)
            {
                for(int j = 1; j<= 4; j++)
                {
                    var Paq = _db.Causales.Where(x => x.IdCasillaDet == id && x.IdEleccion == j).ToList();
                    if(Paq.Count == 1)
                    {
                        if (ca == 3 || ca == 5)
                        {
                            var Paq1 = _db.Causales.Where(x => x.IdCasillaDet == id && x.IdEleccion == j).FirstOrDefault();
                            Paq1.PaqAlteraciones = "Si";
                            Paq1.NumCausales = Paq1.NumCausales + 1;
                        }
                        else
                        {
                            var Paq1 = _db.Causales.Where(x => x.IdCasillaDet == id && x.IdEleccion == j).FirstOrDefault();
                            Paq1.PaqAlteraciones = "No";
                        }
                        _db.SaveChanges();
                    }
                    else
                    {
                        if (ca == 3 || ca == 5)
                        {
                            cles = new Causales();
                            cles.IdCasillaDet = id;
                            cles.IdEleccion = j;
                            cles.PaqSinAec = "No";
                            cles.VotosNMayor = "No";
                            cles.VotosSisBol = "No";
                            cles.VotosSisAec = "No";
                            cles.VotosPartido = "No";
                            cles.ActaIlegible = "No";
                            cles.ActAlteraciones = "No";
                            cles.PaqAlteraciones = "Si";
                            cles.CiuVotaron = "No";
                            cles.BoletasSisCiu = "No";
                            cles.BoletasSisTot = "No";
                            cles.NumCausales = 1;
                            _db.Causales.Add(cles);
                        }
                        else
                        {
                            cles = new Causales();
                            cles.IdCasillaDet = id;
                            cles.IdEleccion = j;
                            cles.PaqSinAec = "No";
                            cles.VotosNMayor = "No";
                            cles.VotosSisBol = "No";
                            cles.VotosSisAec = "No";
                            cles.VotosPartido = "No";
                            cles.ActaIlegible = "No";
                            cles.ActAlteraciones = "No";
                            cles.PaqAlteraciones = "No";
                            cles.CiuVotaron = "No";
                            cles.BoletasSisCiu = "No";
                            cles.BoletasSisTot = "No";
                            _db.Causales.Add(cles);
                        }
                    }                 
                }               
            }
            else
            {
                for (int i = 1; i <= 4; i++)
                {
                    if (ca == 3 || ca == 5)
                    {
                        cles = new Causales();
                        cles.IdCasillaDet = id;
                        cles.IdEleccion = i;
                        cles.PaqSinAec = "No";
                        cles.VotosNMayor = "No";
                        cles.VotosSisBol = "No";
                        cles.VotosSisAec = "No";
                        cles.VotosPartido = "No";
                        cles.ActaIlegible = "No";
                        cles.ActAlteraciones = "No";
                        cles.PaqAlteraciones = "Si";
                        cles.CiuVotaron = "No";
                        cles.BoletasSisCiu = "No";
                        cles.BoletasSisTot = "No";
                        cles.NumCausales = 1;
                        _db.Causales.Add(cles);
                    }
                    else
                    {
                        cles = new Causales();
                        cles.IdCasillaDet = id;
                        cles.IdEleccion = i;
                        cles.PaqSinAec = "No";
                        cles.VotosNMayor = "No";
                        cles.VotosSisBol = "No";
                        cles.VotosSisAec = "No";
                        cles.VotosPartido = "No";
                        cles.ActaIlegible = "No";
                        cles.ActAlteraciones = "No";
                        cles.PaqAlteraciones = "No";
                        cles.CiuVotaron = "No";
                        cles.BoletasSisCiu = "No";
                        cles.BoletasSisTot = "No";
                        _db.Causales.Add(cles);
                    }
                }
            }
            _db.SaveChanges();

            return View();
        }




        [HttpGet]
        public IActionResult GetAll()
        {
            return Json(new { data = _context.Recepcion.GetAll() });
        }

        public IActionResult Detalle(int id)
        {
            
            RegPaqueteVM Paq = new RegPaqueteVM()
            {
                RecPaquetes = new TRecepcionPaquetes(),
                LSeccion = _context.Seccion.GetListaSeccion(),
                LTipoCasilla = _context.TipoCasilla.GetListaTipoCasilla(),

            };
           
            if (id != null)
            {
                Paq.RecPaquetes = _context.Recepcion.Get(id);
            }

            return View(Paq);
        }
        public JsonResult CargarCauGob()
        {
            
            var Id = _UserManager.GetUserId(User);
            var usuario = _db.ApplicationUser.Find(Id);
            var oficina = _db.TOficina.Find(usuario.IdOficina);
            var mun = _db.TMunicipio.Find(oficina.Municipio);         
            var a = _context.Causales.GetListaGobernador(mun.IdMunicipio);

            
            return Json(new { data = a });
        }
        public JsonResult CargarCauPys()
        {
            var Id = _UserManager.GetUserId(User);
            var usuario = _db.ApplicationUser.Find(Id);
            var oficina = _db.TOficina.Find(usuario.IdOficina);
            var mun = _db.TMunicipio.Find(oficina.Municipio);
            var a = _context.Causales.GetListaPys(mun.IdMunicipio);


            return Json(new { data = a });
        }
        public JsonResult CargarCauDip(int id)
        {
            var Id = _UserManager.GetUserId(User);
            var usuario = _db.ApplicationUser.Find(Id);
            var oficina = _db.TOficina.Find(usuario.IdOficina);
            var mun = _db.TMunicipio.Find(oficina.Municipio);
            var a = _context.Causales.GetListaDip(mun.IdMunicipio);
            var b = a.Where(x => x.Distrito == id);

            return Json(new { data = b });
        }
        public JsonResult CargarCauReg(int id)
        {
            var Id = _UserManager.GetUserId(User);
            var usuario = _db.ApplicationUser.Find(Id);
            var oficina = _db.TOficina.Find(usuario.IdOficina);
            var mun = _db.TMunicipio.Find(oficina.Municipio);
            var a = _context.Causales.GetListaReg(mun.IdMunicipio);
            var b = a.Where(x => x.Demarcacion == id);
            return Json(new { data = b });
            
        }

        public class ElementoJsonIntKey
        {
            public int value { get; set; }
            public string text { get; set; }
            public int value1 { get; set; }
            public string text1 { get; set; }
            public string seccion { get; set;}
            public string casilla { get; set;}
            public string cau1 { get; set; }
            public string cau2 { get; set; }
            public string cau3 { get; set; }
            public string cau4 { get; set; }
            public string cau5 { get; set; }
            public string cau6 { get; set; }
            public string cau7 { get; set; }
            public string cau8 { get; set; }
            public string cau9 { get; set; }
            public string cau10 { get; set; }
            public string cau11{ get; set; }
            public int numcau { get; set; }
            public DateTime recep { get; set; }
            public int cont { get; set; }
            public int idr { get; set; }

        }

        
   

    }
}

