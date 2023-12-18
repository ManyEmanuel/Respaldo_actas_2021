using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WebComputos.AccesoDatos.Data.Repository;
using WebComputos.Models;

namespace WebComputos.AccesoDatos.Data
{
    class PartidosRepository : Repository<TPartidos>, IPartidoRepository
    {
        private ApplicationDbContext _db;
        public PartidosRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }
        public IEnumerable<SelectListItem> GetListPartidos()
        {
            return _db.TPartido.Select(i => new SelectListItem()
            {
                Text = i.Nombre,
                Value = i.IdPartido.ToString()
            });
        }

        public void Update(TPartidos Partido)
        {
            var Objbd = _db.TPartido.FirstOrDefault(x => x.IdPartido == Partido.IdPartido);
            Objbd.Independiente = Partido.Independiente;
            Objbd.LogoURL = Partido.LogoURL;
            Objbd.Nombre = Partido.Nombre;
            Objbd.PantoneF = Partido.PantoneF;
            Objbd.PantoneL = Partido.PantoneL;
            Objbd.Prioridad = Partido.Prioridad;
            Objbd.Siglas = Partido.Siglas;
            
        }
    }
}
