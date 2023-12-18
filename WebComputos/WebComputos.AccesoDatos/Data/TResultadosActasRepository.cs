using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Linq;
using WebComputos.AccesoDatos.Data.Repository;
using WebComputos.Models;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using WebComputos.AccesoDatos.Data;

namespace WebComputos.AccesoDatos.Data
{
    public class TResultadosActasRepository :Repository<TResultadosActas>,
        IResultadosActasRepository
    {
        private readonly ApplicationDbContext _db;

        public TResultadosActasRepository(ApplicationDbContext db): base(db)
        {
            _db = db;
        }

        public TResultadosActas Get(object p)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<SelectListItem> GetListasResultados()
        {
            return _db.TResultadosActas.Select(i => new SelectListItem()
            {
                Text = i.IdActa.ToString(),
                Value = i.IdActa.ToString()
            }
            );
        }
    }
}
