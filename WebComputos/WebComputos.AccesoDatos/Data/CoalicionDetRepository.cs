using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WebComputos.AccesoDatos.Data.Repository;
using WebComputos.Models;

namespace WebComputos.AccesoDatos.Data
{
    class CoalicionDetRepository : Repository<TCoalicionDet>, IcoalicionDetRepository
    {
        private ApplicationDbContext _db;

        public CoalicionDetRepository(ApplicationDbContext db): base(db)
        {
            _db = db;
        }
        public IEnumerable<SelectListItem> GetListaCoalicion()
        {
            return _db.TCoaliciondet.Select(i => new SelectListItem()
            {

            });
        }

        public void Update(TCoalicionDet coaliciondet)
        {
            var Obj = _db.TCoaliciondet.FirstOrDefault(s => s.IdCoalicionDet == coaliciondet.IdCoalicionDet);
            Obj.Activo = coaliciondet.Activo;
            Obj.Coalicion = coaliciondet.Coalicion;
            Obj.Partido = coaliciondet.Partido;
            
        }
    }
}
