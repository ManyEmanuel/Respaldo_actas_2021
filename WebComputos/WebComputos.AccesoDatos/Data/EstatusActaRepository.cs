using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Linq;
using WebComputos.AccesoDatos.Data.Repository;
using WebComputos.Models;

namespace WebComputos.AccesoDatos.Data
{
   public class EstatusActaRepository  : Repository<EstatusActa>, IEstatusActaRepository
    {
        private readonly ApplicationDbContext _db;
        public EstatusActaRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }

        public EstatusActa Get(object p)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<SelectListItem> GetEstatusActa()
        {
            return _db.EstatusActas.Select(i => new SelectListItem()
            {
                Text = i.Descripcion,
                Value = i.IdEstatus.ToString()
            });
        }
    }
}
