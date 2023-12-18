using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Text;
using WebComputos.AccesoDatos.Data.Repository;
using WebComputos.Models;

namespace WebComputos.AccesoDatos.Data
{
    public class CombinacinesdetRepository: Repository<CombinacionesDet>, ICombinacionesDetRepository
    {
        private readonly ApplicationDbContext _db;
        public CombinacinesdetRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }

        public IEnumerable<SelectListItem> GetListaDemarcacion()
        {
            throw new NotImplementedException();
        }

        public void Update(Combinaciones Combinaciones)
        {
            throw new NotImplementedException();
        }
    }
}
