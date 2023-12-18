using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WebComputos.AccesoDatos.Data.Repository;
using WebComputos.Models;

namespace WebComputos.AccesoDatos.Data
{
    class CombinacionesRepository : Repository<Combinaciones>, ICombinacionesRepository
    {
        private readonly ApplicationDbContext _db;
        public CombinacionesRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }

        public IEnumerable<SelectListItem> GetListaCombinaciones()
        {
            return _db.Combinaciones.Select(i => new SelectListItem()
            {
                Text = i.Combinacion,
                Value = i.idCombinacion.ToString()
            });
        }

        public void Update(Combinaciones combi)
        {
            throw new NotImplementedException();
        }
    }
}
