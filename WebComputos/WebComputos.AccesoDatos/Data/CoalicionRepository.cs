using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WebComputos.AccesoDatos.Data.Repository;
using WebComputos.Models;

namespace WebComputos.AccesoDatos.Data
{
    public class CoalicionRepository : Repository<TCoalicion>, ICoalicionRepository
    {
        private ApplicationDbContext _db;
        public CoalicionRepository(ApplicationDbContext db):base (db)
        {
            _db = db;
        }

        public IEnumerable<SelectListItem> GetListaCoalicion()
        {
            return _db.TCoalicion.Select(i => new SelectListItem()
            {
                Text = i.Nombre,
                Value = i.IdCoalicion.ToString()
            });
        }

        public void Update(TCoalicion Coalicion)
        {
            var Objbd = _db.TCoalicion.FirstOrDefault(x => x.IdCoalicion == Coalicion.IdCoalicion);
            Objbd.Nombre = Coalicion.Nombre;
            Objbd.Siglas = Coalicion.Siglas;
            Objbd.Logo = Coalicion.Logo;
        }
    }
}
