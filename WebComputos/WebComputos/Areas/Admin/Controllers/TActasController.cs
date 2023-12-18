using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.EntityFrameworkCore;
using WebComputos.AccesoDatos.Data;
using WebComputos.AccesoDatos.Data.Repository;
using WebComputos.Models;
using WebComputos.Models.ViewModels;

namespace WebComputos.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class TActasController : Controller
    {
        private readonly IContenedorTrabajo _context;
        private ApplicationDbContext _db;
        private readonly UserManager<ApplicationUser> _UserManager;

        public TActasController(IContenedorTrabajo context, ApplicationDbContext db, UserManager<ApplicationUser> UserManager)
        {
            _context = context;
            _db = db;
            _UserManager = UserManager;
        }
        [HttpGet]
        public IActionResult Entrega()
        {
            return View();
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Create()
        {
            var Id = _UserManager.GetUserId(User);
            var usuario = _db.ApplicationUser.Find(Id);
            var oficina = _db.TOficina.Find(usuario.IdOficina);
            var mun = _db.TMunicipio.Find(oficina.Municipio);
            ActasVM Act = new ActasVM()
            {
                Actas = new TActas(),                
                LSeccionGob = _context.Seccion.ListaSeccionByMunicipioGob(mun.IdMunicipio),
                LSeccionPys = _context.Seccion.ListaSeccionByMunicipioPys(mun.IdMunicipio),
                LSeccionDip = _context.Seccion.ListaSeccionByMunicipioDip(mun.IdMunicipio),
                LSeccionReg = _context.Seccion.ListaSeccionByMunicipioReg(mun.IdMunicipio),
                LEstatusActa = _context.EstatusActa.GetEstatusActa()
            };
            return View(Act);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]

        public IActionResult Create(ActasVM actaVM)
        {
            
            if (ModelState.IsValid)
            {
                
                _context.Acta.Add(actaVM.Actas);
                _context.Save();
                int id = actaVM.Actas.IdDetalleActa;
                int est = actaVM.Actas.Estatus;
                int idact = actaVM.Actas.IdActa;
                RegistroEle(id);
                RegistroCau(id, est);
                return RedirectToAction(nameof(Resultados));
            }
            return View(actaVM);
        }

        public IActionResult RegistroEle (int id)
        {
            var deta = _db.DetallesActas.Where(x => x.IdActaDetalle == id).FirstOrDefault();
            int cadet = deta.IdCasillaDet;
            int ele = deta.IdEleccion;

            var est = _db.EstatusEntregas.Where(x => x.IdCasillaDet == cadet).FirstOrDefault();
            if(ele == 1)
            {
                est.Gobernador = "Si";
            }
            if(ele == 2)
            {
                est.Pys = "Si";
            }
            if(ele == 3)
            {
                est.Diputado = "Si";
            }
            if (ele == 4)
            {
                est.Regidor = "Si";
            }
            _db.SaveChanges();
            return View();
        }
        public IActionResult RegistroCau(int id, int ca)
        {
            var deta = _db.DetallesActas.Where(x => x.IdActaDetalle == id).FirstOrDefault();
            int cadet = deta.IdCasillaDet;
            int ele = deta.IdEleccion;
            var cau = _db.Causales.Where(x => x.IdCasillaDet == cadet && x.IdEleccion == ele).ToList();
            Causales cles;
            if(cau.Count == 1)
            {
                var cau1 = _db.Causales.Where(x => x.IdCasillaDet == cadet && x.IdEleccion == ele).FirstOrDefault();
                if (ca == 3)
                {                  
                    cau1.PaqSinAec = "Si";
                    cau1.NumCausales = cau1.NumCausales + 1;
                }
                if (ca == 7)
                {
                    
                    cau1.ActaIlegible = "Si";
                    cau1.NumCausales = cau1.NumCausales + 1;
                }
                if (ca == 9)
                {
                    
                    cau1.ActAlteraciones = "Si";
                    cau1.NumCausales = cau1.NumCausales + 1;
                }
                _db.SaveChanges();
            }
            else
            {
                if(ca!= 3 && ca!=7 && ca != 9)
                {
                    cles = new Causales();
                    cles.IdCasillaDet = cadet;
                    cles.IdEleccion = ele;
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
                if (ca == 3)
                {
                    cles = new Causales();
                    cles.PaqSinAec = "Si";                   
                    cles.IdCasillaDet = cadet;
                    cles.IdEleccion = ele;
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
                    cles.NumCausales = cles.NumCausales + 1;
                    _db.Causales.Add(cles);
                }
                if (ca == 7)
                {
                    cles = new Causales();
                    cles.IdCasillaDet = cadet;
                    cles.IdEleccion = ele;
                    cles.PaqSinAec = "No";
                    cles.VotosNMayor = "No";
                    cles.VotosSisBol = "No";
                    cles.VotosSisAec = "No";
                    cles.VotosPartido = "No";
                    cles.ActaIlegible = "Si";
                    cles.ActAlteraciones = "No";
                    cles.PaqAlteraciones = "No";
                    cles.CiuVotaron = "No";
                    cles.BoletasSisCiu = "No";
                    cles.BoletasSisTot = "No";
                    cles.NumCausales = cles.NumCausales + 1;
                    _db.Causales.Add(cles);
                    
                }
                if (ca == 9)
                {
                    cles = new Causales();
                    cles.IdCasillaDet = cadet;
                    cles.IdEleccion = ele;
                    cles.PaqSinAec = "No";
                    cles.VotosNMayor = "No";
                    cles.VotosSisBol = "No";
                    cles.VotosSisAec = "No";
                    cles.VotosPartido = "No";
                    cles.ActaIlegible = "No";
                    cles.ActAlteraciones = "Si";
                    cles.PaqAlteraciones = "No";
                    cles.CiuVotaron = "No";
                    cles.BoletasSisCiu = "No";
                    cles.BoletasSisTot = "No";
                    cles.NumCausales = cles.NumCausales + 1;
                    _db.Causales.Add(cles);                  
                }

            }
            _db.SaveChanges();
            return View();
        }

        [HttpGet]
        public IActionResult Resultados()
        {
            int acta = 0;
            int detact = 0;
            DetallesActas dres;
            ResultadosVM Resvm = new ResultadosVM()
            {
                LActas = _db.TActas.ToList()
            };
            acta = Resvm.LActas.Last().IdActa;
            detact = Resvm.LActas.Last().IdDetalleActa;
            var Resu = _db.DetallesActas.Where(x => x.IdActaDetalle == detact).FirstOrDefault();
            if(Resu.Capturado == false)
            {

                Resu.Capturado = true;
                _db.SaveChanges();
            }
            
            var partidos = _context.Partido.GetAll(x=> x.Independiente == false).OrderBy(x=> x.Prioridad);
            var coalicion = _context.Combinacion.GetAll().OrderBy(x=> x.idCombinacion); 
            var independientes = _context.Partido.GetAll(x => x.Independiente == true);
            TResultadosActas res;

            var Resultados = _db.TResultadosActas.Where(x => x.IdActa == acta).ToList();
            if(Resultados.Count() == 0) 
            {                 
                foreach (var elemento in partidos)
                {
                    res = new TResultadosActas();
                    res.IdPartido = elemento.IdPartido;
                    res.IdActa = acta;
                    res.VotosRegistrados = 0;
                    _db.TResultadosActas.Add(res);
                }
                
                
                foreach (var elemento in coalicion)
                {
                    res = new TResultadosActas();
                    res.IdCombinacion = elemento.idCombinacion;
                    res.IdCoalicion = elemento.Coalicion;
                    res.IdActa = acta;
                    res.VotosRegistrados = 0;
                    _db.TResultadosActas.Add(res);
                }
               
                
                foreach (var elemento in independientes)
                {
                    res = new TResultadosActas();
                    res.IdIndependiente = elemento.IdPartido;
                    res.IdActa = acta;
                    res.VotosRegistrados = 0;
                    _db.TResultadosActas.Add(res);
                }
                for (int i = 1; i <= 3; i++)
                {
                    if (i == 1)
                    {
                        res = new TResultadosActas();
                        res.NoRegistrados = 1;
                        res.IdActa = acta;
                        res.VotosRegistrados = 0;
                        _db.TResultadosActas.Add(res);
                    }
                    if (i == 2)
                    {
                        res = new TResultadosActas();
                        res.Nulos = 1;
                        res.IdActa = acta;
                        res.VotosRegistrados = 0;
                        _db.TResultadosActas.Add(res);
                    }
                    if (i == 3)
                    {
                        res = new TResultadosActas();
                        res.Total = 1;
                        res.IdActa = acta;
                        res.VotosRegistrados = 0;
                        _db.TResultadosActas.Add(res);
                    }
                }
              _db.SaveChanges();
            }

            ResultadosVM Res = new ResultadosVM()
            {
                LCombinaciones = _db.Combinaciones.ToList().OrderBy(x => x.idCombinacion),
                LPArtidos = _db.TPartido.ToList().OrderBy(x=> x.IdPartido),
                LActas = _db.TActas.ToList(),
                Resultado = _db.TResultadosActas.Where(x=> x.IdActa == acta).ToList()
                

            };

            var par = _db.TPartido.ToList().OrderBy(x=> x.IdPartido).ThenBy(x=> x.Prioridad);
            var com = _db.Combinaciones.ToList().OrderBy(x=> x.idCombinacion);
            var re = _db.TResultadosActas.Where(x=> x.IdActa == acta).ToList();
            ViewBag.partido = par;
            ViewBag.combinacion = com;
            ViewBag.Resact = re;

            IEnumerable<TResultadosActas> Tres = _context.ResActas.GetAll(x=> x.IdActa==acta);
            return View(Tres);
        }



        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult CreatePar(IList<TResultadosActas> revm)
        {
           
            //int nor = 0;
            int nul = 0;
            int tot = 0;
            int id = 0;
            foreach (var i in revm) {
                TResultadosActas res = new TResultadosActas();
                res = _context.ResActas.Get(i.IdResultadoActa);
                res.VotosRegistrados = i.VotosRegistrados;
                if (i.Total == 1)
                {
                    tot = i.VotosRegistrados;
                    id = i.IdActa;
                }
                if (i.Nulos == 1)
                {
                    nul = i.VotosRegistrados;
                }
                // nor = i.NoRegistrados;
                // nul = i.Nulos;
                // tot = i.Total;
                // id = i.IdActa;
                _context.Save();
            }

            ProcesosCausales(id, tot, nul);
            return RedirectToAction("Index");
        }

        
        public IActionResult ProcesosCausales(int id, int totAEC, int Nulos)
        {
            // id = Numero de Acta
            // totAEC = Total del Acta
            // Nulos = Votos Nulos
            // totsis = Total del Sistema
            // dif = Diferencia entre el primero y el segundo lugar
            var totsis = _db.TResultadosActas.Where(x => x.IdActa == id && x.Total == 0).OrderByDescending(x=> x.VotosRegistrados).ToList();
            int Tsis = totsis.Sum(x => x.VotosRegistrados);     
            int uno = totsis.Select(x => x.VotosRegistrados).ElementAt(0);
            int dos = totsis.Select(x => x.VotosRegistrados).ElementAt(1);
            int dif = uno - dos;
            VotosNulosMayor(id, dif, Nulos);
            TotalVotos(id, Tsis, totAEC);
            UnSoloVoto(id);
            VotosCiudadano(id, Tsis);
            BoletasSobrantes(id, Tsis);
            return View();
        }

        public IActionResult VotosNulosMayor (int id, int dif, int Nulos)
        {
            if(Nulos > dif)
            {
                var res = _db.TActas.Where(x => x.IdActa == id).FirstOrDefault();
                int detacta = res.IdDetalleActa;
                var res1 = _db.DetallesActas.Where(x => x.IdActaDetalle == detacta).FirstOrDefault();
                int idcasdet = res1.IdCasillaDet;
                int idele = res1.IdEleccion;
                var res2 = _db.Causales.Where(x => x.IdEleccion == idele && x.IdCasillaDet == idcasdet).FirstOrDefault();
                res2.VotosNMayor = "Si";
                _db.SaveChanges();

            }
            return View();
        }

        public IActionResult TotalVotos(int id, int totsis, int totacta)
        {
            var res = _db.TActas.Where(x => x.IdActa == id).FirstOrDefault();
            int detacta = res.IdDetalleActa;
            var res1 = _db.DetallesActas.Where(x => x.IdActaDetalle == detacta).FirstOrDefault();
            int idcasdet = res1.IdCasillaDet;
            int idele = res1.IdEleccion;
            var res2 = _db.TCasillaDet.Where(x => x.IdCasillaDet == idcasdet).FirstOrDefault();
            int bol = res2.BoletasEnt;
            if(totsis > bol)
            {
                var resr = _db.Causales.Where(x => x.IdEleccion == idele && x.IdCasillaDet == idcasdet).FirstOrDefault();
                resr.VotosSisBol = "Si";
                
            }

            if(totsis != totacta)
            {
                var resr = _db.Causales.Where(x => x.IdEleccion == idele && x.IdCasillaDet == idcasdet).FirstOrDefault();
                resr.VotosSisAec = "Si";
                
            }
            _db.SaveChanges();
            return View();
        }

        public IActionResult UnSoloVoto(int id)
        {
            var solo = _db.TResultadosActas.Where(x => x.IdActa == id && x.Total == 0 && x.VotosRegistrados != 0).OrderByDescending(x => x.VotosRegistrados).ToList();
            if (solo.Count == 1)
            {
                var res = _db.TActas.Where(x => x.IdActa == id).FirstOrDefault();
                int detacta = res.IdDetalleActa;
                var res1 = _db.DetallesActas.Where(x => x.IdActaDetalle == detacta).FirstOrDefault();
                int idcasdet = res1.IdCasillaDet;
                int idele = res1.IdEleccion;
                var resr = _db.Causales.Where(x => x.IdEleccion == idele && x.IdCasillaDet == idcasdet).FirstOrDefault();
                resr.VotosPartido = "Si";
            }                
            _db.SaveChanges();

            return View();
        }
        public IActionResult VotosCiudadano(int id, int totsis)
        {
            
                var res = _db.TActas.Where(x => x.IdActa == id).FirstOrDefault();
                int detacta = res.IdDetalleActa;
                int pervot = res.VotosCiu;
                if (pervot != totsis)
                {
                var res1 = _db.DetallesActas.Where(x => x.IdActaDetalle == detacta).FirstOrDefault();
                int idcasdet = res1.IdCasillaDet;
                int idele = res1.IdEleccion;
                var res2 = _db.Causales.Where(x => x.IdEleccion == idele && x.IdCasillaDet == idcasdet).FirstOrDefault();
                res2.CiuVotaron = "Si";
            }

               
                _db.SaveChanges();

            
            return View();
        }

        public IActionResult BoletasSobrantes(int id, int totsis) 
        {
            int caus = 0;
            var res = _db.TActas.Where(x => x.IdActa == id).FirstOrDefault();
            int detacta = res.IdDetalleActa;
            //Ciudadanos que Votaron
            int pervot = res.VotosCiu;
            //Boletas Sobrantes
            int sobra = res.Sobrantes;
            var res1 = _db.DetallesActas.Where(x => x.IdActaDetalle == detacta).FirstOrDefault();
            int idcasdet = res1.IdCasillaDet;
            int idele = res1.IdEleccion;
            var res2 = _db.TCasillaDet.Where(x => x.IdCasillaDet == idcasdet).FirstOrDefault();
            // Boletas Entregadas
            int bol = res2.BoletasEnt;
            var resr = _db.Causales.Where(x => x.IdEleccion == idele && x.IdCasillaDet == idcasdet).FirstOrDefault();
            //Boletas Sobrantes mas ciudadanos que votaron mayor a boletas sobrantes
            if ((sobra + pervot) > bol)
            {                
                resr.BoletasSisCiu = "Si";
            }

            //Boletas Sobrantes mas total de votos del sistema mayor a boletas sobrantes
            if ((sobra + totsis) > bol)
            {
                
                resr.BoletasSisTot = "Si";
                 
            }
            caus = resr.IdCausales;
            _db.SaveChanges();
            ContarSi(caus);
            return View();
        }

        public IActionResult ContarSi(int id)
        {
            int contador = 0;
            var contcausal = _db.Causales.Where(x => x.IdCausales == id).FirstOrDefault();
            if (contcausal.PaqSinAec == "Si")
            {
                contador++;
            }
            if (contcausal.VotosNMayor == "Si")
            {
                contador++;
            }
            if (contcausal.VotosSisBol == "Si")
            {
                contador++;
            }
            if (contcausal.VotosSisAec == "Si")
            {
                contador++;
            }
            if (contcausal.VotosPartido == "Si")
            {
                contador++;
            }
            if (contcausal.ActaIlegible == "Si")
            {
                contador++;
            }
            if (contcausal.ActAlteraciones == "Si")
            {
                contador++;
            }
            if (contcausal.PaqAlteraciones == "Si")
            {
                contador++;
            }
            if (contcausal.CiuVotaron == "Si")
            {
                contador++;
            }
            if (contcausal.BoletasSisCiu == "Si")
            {
                contador++;
            }
            if (contcausal.BoletasSisTot == "Si")
            {
                contador++;
            }
            contcausal.NumCausales = contcausal.NumCausales +contador;
            _db.SaveChanges();
            return View();
        }



        public JsonResult CargarGob(int ide, int ids)
        {
            var Id = _UserManager.GetUserId(User);
            var usuario = _db.ApplicationUser.Find(Id);
            var oficina = _db.TOficina.Find(usuario.IdOficina);
            var mun = _db.TMunicipio.Find(oficina.Municipio);
            List<ElementoJsonIntKey> lstda = new List<ElementoJsonIntKey>();
            lstda = (from c in _db.TCasillaDet             
                     join d in _db.DetallesActas on c.IdCasillaDet equals d.IdCasillaDet
                     join s in _db.TSeccion on c.Seccion equals s.idSeccion
                     where c.Seccion == ids && d.IdEleccion == ide && d.Capturado == false && s.Municipio == mun.IdMunicipio
                     select new ElementoJsonIntKey
                     {
                         detCas = c.Seccion,
                         numCas = c.TipoCasilla,
                         value = d.IdActaDetalle,
                         text = c.Nombre
                     }).OrderBy(x=> x.detCas).ThenBy(x=> x.numCas).ToList();

            
            return Json(new SelectList(lstda, "value", "text"));
        }

        public JsonResult CargarReg()
        {
            var Id = _UserManager.GetUserId(User);
            var usuario = _db.ApplicationUser.Find(Id);
            var oficina = _db.TOficina.Find(usuario.IdOficina);
            var mun = _db.TMunicipio.Find(oficina.Municipio);
            List<ElementoJsonIntKey> lstda = new List<ElementoJsonIntKey>();
            lstda = (
                    from d in _db.DetallesActas
                    join a in _db.TActas on d.IdActaDetalle equals a.IdDetalleActa
                    join c in _db.TCasillaDet on d.IdCasillaDet equals c.IdCasillaDet
                    join s in _db.TSeccion on c.Seccion equals s.idSeccion
                    join e in _db.TtipoEleccion on  d.IdEleccion equals e.idTipoEleccion

                    where d.Capturado == true && s.Municipio == mun.IdMunicipio
                    select new ElementoJsonIntKey
                     {
                         seccion = s.seccion,
                         casilla = c.Nombre,
                         eleccion = e.Nombre,
                         rpaq = a.IdActa
                         

                     }).ToList();
            return Json(new { data = lstda });
        }

        public JsonResult CargarDoc()
        {
            var Id = _UserManager.GetUserId(User);
            var usuario = _db.ApplicationUser.Find(Id);
            var oficina = _db.TOficina.Find(usuario.IdOficina);
            var mun = _db.TMunicipio.Find(oficina.Municipio);
            List<ElementoJsonIntKey> lstda = new List<ElementoJsonIntKey>();
            lstda = (
                    from d in _db.TCasillaDet
                    join e in _db.EstatusEntregas on d.IdCasillaDet equals e.IdCasillaDet
                    join s in _db.TSeccion on d.Seccion equals s.idSeccion
                    where s.idSeccion == d.Seccion && s.Municipio == mun.IdMunicipio
                    
                    select new ElementoJsonIntKey
                    {
                        seccion = s.seccion,
                        casilla = d.Nombre,
                        paquetes = e.Paquetes,
                        agob = e.Gobernador,
                        apys = e.Pys,
                        adip = e.Diputado,
                        areg = e.Regidor,
                        rpaq = d.TipoCasilla


                    }).OrderBy(x=> x.seccion).ThenBy(x=> x.rpaq).ToList();
            return Json(new { data = lstda });
        }

        [HttpGet]
        public IActionResult Detalle(int id)
        {
            ActasVM Act = new ActasVM()
            {
                Actas = new TActas(),
                LEstatusActa = _context.EstatusActa.GetEstatusActa()
            };
            if(id != null)
            {
                Act.Actas = _context.Acta.Get(id);
            }

            return View(Act);
        }

        [HttpGet]
        public ActionResult DetalleResultado(int id)
        {

            var par = _db.TPartido.ToList();
            var com = _db.Combinaciones.ToList();
            var re = _db.TResultadosActas.Where(x => x.IdActa == id).ToList();
            ViewBag.Resact = re;
            ViewBag.partido = par;
            ViewBag.combinacion = com;

            IEnumerable<TResultadosActas> Tres = _context.ResActas.GetAll(x => x.IdActa == id);
            return View(Tres);
        }


        public class ElementoJsonIntKey
        {
            //public int value { get; set; }
            //public string text { get; set; }
            //public int value1 { get; set; }
            //public string text1 { get; set; }
            public string seccion { get; set; }
            public string casilla { get; set; }
            public string eleccion { get; set; }
            //public DateTime recep { get; set; }
            public int rpaq { get; set; }
            public int tele { get; set; }

            public int value { get; set; }
            public string text { get; set; }
            public int idde { get; set; }
            public int detCas { get; set; }
            public int numCas { get; set; }
            public string paquetes { get; set; }
            public string agob { get; set; }
            public string apys { get; set; }
            public string adip { get; set; }
            public string areg { get; set; }

        }

    }
}
