using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Linq;
using WebComputos.AccesoDatos.Data.Repository;
using WebComputos.Models;

namespace WebComputos.AccesoDatos.Data
{
    public class DetallesActasRepository : Repository<DetallesActas>
    {
        private readonly ApplicationDbContext _db;
        public DetallesActasRepository (ApplicationDbContext db) : base(db)
        {
            _db = db;
        }

        public DetallesActas Get(object p)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<SelectListItem> GetListaDetActa()
        {
            return _db.DetallesActas.Select(i => new SelectListItem()
            {
                Text = i.Capturado.ToString(),
                Value = i.IdCasillaDet.ToString()
            });
        }
    }
}
