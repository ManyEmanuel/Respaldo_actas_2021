using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WebComputos.AccesoDatos.Data.Repository;
using WebComputos.Models;

namespace WebComputos.AccesoDatos.Data
{
    class TipoEleccionReporisoty: Repository<TtipoEleccion>, ICatEleccionRepository
    {
        private ApplicationDbContext _db;
        public TipoEleccionReporisoty(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }

        public IEnumerable<SelectListItem> GetListaTipoEleccion()
        {
            return _db.TtipoEleccion.Select(i => new SelectListItem()
            {
                Text = i.Nombre,
                Value = i.idTipoEleccion.ToString()
            });
        }

        public void Update(TtipoEleccion TipoEleccion)
        {
            var ObjBd = _db.TtipoEleccion.FirstOrDefault(s => s.idTipoEleccion == TipoEleccion.idTipoEleccion);
            ObjBd.Nombre = TipoEleccion.Nombre;
            ObjBd.Siglas = TipoEleccion.Siglas;
            _db.SaveChanges();

        }
    }
}
