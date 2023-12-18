using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WebComputos.AccesoDatos.Data.Repository;
using WebComputos.Models;

namespace WebComputos.AccesoDatos.Data
{
    public class TipoCasillaRepository : Repository<TtipoCasilla> , ItipoCasillaRepository
    {
        private ApplicationDbContext _db;

        public TipoCasillaRepository(ApplicationDbContext db) :base(db)
        {
            _db = db;
        }

        public IEnumerable<SelectListItem> GetListaTipoCasilla()
        {
            return _db.TtipoCasilla.Select(i => new SelectListItem()
            {
                Text = i.Nombre,
                Value = i.IdTipoCasilla.ToString()
            });
        }

        public void Update(TtipoCasilla TipoCasilla)
        {
            var ObjBd = _db.TtipoCasilla.FirstOrDefault(s => s.IdTipoCasilla == TipoCasilla.IdTipoCasilla);
            ObjBd.Nombre = TipoCasilla.Nombre;
            ObjBd.Siglas = TipoCasilla.Siglas;
            _db.SaveChanges();
        }
    }
}
