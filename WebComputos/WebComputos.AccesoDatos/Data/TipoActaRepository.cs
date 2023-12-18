using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WebComputos.AccesoDatos.Data.Repository;
using WebComputos.Models;

namespace WebComputos.AccesoDatos.Data
{
    class TipoActaRepository : Repository<TtipoActa>, ITipoActaRepository
    {
        private ApplicationDbContext _db;

        public TipoActaRepository(ApplicationDbContext db): base(db)
        {
            _db = db;
        }
        public IEnumerable<SelectListItem> GetListaTipoActa()
        {
            return _db.TtipoActa.Select(i => new SelectListItem()
            {
                Text = i.Nombre,
                Value = i.IdActa.ToString()
            });
        }

        public void Update(TtipoActa TipoActa)
        {
            var Objbd = _db.TtipoActa.FirstOrDefault(s => s.IdActa == TipoActa.IdActa);
            Objbd.Nombre = TipoActa.Nombre;
            Objbd.TipoEleccion = TipoActa.TipoEleccion;
            _db.SaveChanges();
        }
    }
}
