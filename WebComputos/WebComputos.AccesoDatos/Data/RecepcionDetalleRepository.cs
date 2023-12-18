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

namespace WebComputos.AccesoDatos.Data
{
    public class RecepcionDetalleRepository : Repository<RecepcionDetalle>,
    IRecepcionDetalleRepository
    {
        private readonly ApplicationDbContext _db;

        public RecepcionDetalleRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }

        public RecepcionDetalle Get(object p)
        {
            throw new NotImplementedException();
        }
    }
}
