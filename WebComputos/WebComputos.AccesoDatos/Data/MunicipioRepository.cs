using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WebComputos.AccesoDatos.Data.Repository;
using WebComputos.Models;

namespace WebComputos.AccesoDatos.Data
{
    class MunicipioRepository : Repository<TMunicipio>, IMunicipioRepository 
    {
        private readonly ApplicationDbContext _db;

        public MunicipioRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }

        public IEnumerable<SelectListItem> GetListaMunicipio()
        {
            return _db.TMunicipio.Select(i => new SelectListItem()
            {
                Text = i.Nombre,
                Value = i.IdMunicipio.ToString()
            });
        }

        public void Update(TMunicipio municipio)
        {
            var ObjBD = _db.TMunicipio.FirstOrDefault(s => s.IdMunicipio == municipio.IdMunicipio);
            ObjBD.NoEstado = municipio.NoEstado;
            ObjBD.Nombre = municipio.Nombre;
            ObjBD.CabMun = municipio.CabMun;
            ObjBD.Estado = municipio.Estado;
            _db.SaveChanges();
        }
    }
}
