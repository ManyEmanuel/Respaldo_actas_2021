using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using WebComputos.AccesoDatos.Data.Repository;
using WebComputos.Models;

namespace WebComputos.AccesoDatos.Data
{
    class DistritoRepository : Repository<TDistrito>, IDistritoReporitory
    {

        private readonly ApplicationDbContext _db;

        public DistritoRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }

        public List<int?> DistritoBySeccion(int idmun)
        {
            var distrito = _db.TSeccion.Where(x => x.Municipio == idmun).OrderBy(x=> x.Distrito).Select(x=> x.Distrito).Distinct().ToList();
          
            return distrito;
        }

        public IEnumerable<SelectListItem> GetListaDistrito()
        {
            return _db.TDistrito.Select(i => new SelectListItem()
            {
                Text = i.Nombre,
                Value = i.IdDistrito.ToString()
            });
        }

        public void Update(TDistrito distrito)
        {
            var ObjBd = _db.TDistrito.FirstOrDefault(s => s.IdDistrito == distrito.IdDistrito);
            ObjBd.Nombre = distrito.Nombre;
            _db.SaveChanges();
        }
    }
}
