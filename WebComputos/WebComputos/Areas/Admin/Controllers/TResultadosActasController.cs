using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
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
    public class TResultadosActasController : Controller
    {
        private readonly IContenedorTrabajo _context;
        private ApplicationDbContext _db;

        public TResultadosActasController(IContenedorTrabajo context, ApplicationDbContext db)
        {
            _context = context;
            _db = db;
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Create()
        {
            TResultadosActasVM res = new TResultadosActasVM
            {
                Resultados = new TResultadosActas()

            };
            return View(res);
        }

        [HttpGet]
        public IActionResult Resultados()
        {
            ResultadosVM Res = new ResultadosVM()
            {
                LCombinaciones = _db.Combinaciones.ToList().OrderBy(x => x.idCombinacion),
                LPArtidos = _db.TPartido.ToList(),
                LActas = _db.TActas.ToList()

            };
            return View(Res);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(TResultadosActasVM ReActa)
        {
          if (ModelState.IsValid)
        {
            _context.ResActas.Add(ReActa.Resultados);
            _context.Save();
         return RedirectToAction(nameof(Index));
         }
         return View(ReActa);
        }



        public JsonResult CargaElementos()
        {
            List<ElementoJsonIntKey> list = new List<ElementoJsonIntKey>();
                list = (from p in _db.TPartido
                        where p.Independiente == false
                        
                        select new ElementoJsonIntKey
                        {
                            idpartido = p.IdPartido,                           
                            Partido = p.Siglas,

                        }).ToList();
            return Json(new { data = list });
        }

        public JsonResult CargaCombina()
        {
            List<ElementoJsonIntKey> list = new List<ElementoJsonIntKey>();
            list = (from c in _db.Combinaciones

                    select new ElementoJsonIntKey
                    {
                        idcombinacion = c.idCombinacion,
                        Coalicion = c.Combinacion,
                    }).OrderBy(s => s.idcombinacion).ToList();
            return Json(new { data = list });
        }
        // GET: Admin/TResultadosActas
        /*public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.TResultadosActas.Include(t => t.LRespuesta);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: Admin/TResultadosActas/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tResultadosActas = await _context.TResultadosActas
                .Include(t => t.LRespuesta)
                .FirstOrDefaultAsync(m => m.IdResultadoActa == id);
            if (tResultadosActas == null)
            {
                return NotFound();
            }

            return View(tResultadosActas);
        }*/

        // GET: Admin/TResultadosActas/Create


        // POST: Admin/TResultadosActas/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        /*[HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdResultadoActa,IdPartido,IdCoalicion,IdCombinacion,Nulos,Total,VotosRegistrados,IdActa")] TResultadosActas tResultadosActas)
        {
            if (ModelState.IsValid)
            {
                _context.Add(tResultadosActas);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["IdActa"] = new SelectList(_context.TActas, "IdActa", "IdActa", tResultadosActas.IdActa);
            return View(tResultadosActas);
        }

        // GET: Admin/TResultadosActas/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tResultadosActas = await _context.TResultadosActas.FindAsync(id);
            if (tResultadosActas == null)
            {
                return NotFound();
            }
            ViewData["IdActa"] = new SelectList(_context.TActas, "IdActa", "IdActa", tResultadosActas.IdActa);
            return View(tResultadosActas);
        }

        // POST: Admin/TResultadosActas/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdResultadoActa,IdPartido,IdCoalicion,IdCombinacion,Nulos,Total,VotosRegistrados,IdActa")] TResultadosActas tResultadosActas)
        {
            if (id != tResultadosActas.IdResultadoActa)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(tResultadosActas);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TResultadosActasExists(tResultadosActas.IdResultadoActa))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            ViewData["IdActa"] = new SelectList(_context.TActas, "IdActa", "IdActa", tResultadosActas.IdActa);
            return View(tResultadosActas);
        }

        // GET: Admin/TResultadosActas/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tResultadosActas = await _context.TResultadosActas
                .Include(t => t.LRespuesta)
                .FirstOrDefaultAsync(m => m.IdResultadoActa == id);
            if (tResultadosActas == null)
            {
                return NotFound();
            }

            return View(tResultadosActas);
        }

        // POST: Admin/TResultadosActas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var tResultadosActas = await _context.TResultadosActas.FindAsync(id);
            _context.TResultadosActas.Remove(tResultadosActas);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TResultadosActasExists(int id)
        {
            return _context.TResultadosActas.Any(e => e.IdResultadoActa == id);
        }*/

        public class ElementoJsonIntKey
        {
            public int idpartido { get; set; }
            public int idcoalicion { get; set; }
            public int idcombinacion { get; set; }
            public int idnulos { get; set; }
            public int idtotal { get; set; }
            public int total { get; set; }
            public string Partido { get; set; }
            public string Coalicion { get; set; }


        }
    }
}
