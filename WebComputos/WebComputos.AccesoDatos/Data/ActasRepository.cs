using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using WebComputos.AccesoDatos.Data.Repository;
using WebComputos.Models;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using WebComputos.AccesoDatos.Data;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace WebComputos.AccesoDatos.Data
{
    public class ActasRepository : Repository<TActas>,
        IActasRepository
    {
        private readonly ApplicationDbContext _db;

        public ActasRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }

        public TActas Get(object p)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<SelectListItem> GetListaActas()
        {
            return _db.TActas.Select(i => new SelectListItem()
            {
                Text = i.IdActa.ToString(),
                Value = i.IdActa.ToString()
            }
            );
        }
       
        
        

    }
    
    
}
