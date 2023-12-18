using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WebComputos.AccesoDatos.Data.Repository;
using WebComputos.Models;

namespace WebComputos.AccesoDatos.Data
{
    class DemarcacionRepository: Repository<TDemarcacion>, IDemarcacionRepository
    {
        private readonly ApplicationDbContext _db;

        public DemarcacionRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }

        public IEnumerable<SelectListItem> GetListaDemarcacion()
        {
            return _db.TDemarcacion.Select(i => new SelectListItem()
            {
                Text = i.Nombre,
                Value = i.idDemarcacion.ToString()
            });
        }

        public void Update(TDemarcacion Demarcacion)
        {
            var Objbd = _db.TDemarcacion.FirstOrDefault(s => s.idDemarcacion == Demarcacion.idDemarcacion);
            Objbd.Municipio = Demarcacion.Municipio;
            Objbd.noDemarcacion = Demarcacion.noDemarcacion;
            Objbd.Redemarcacion = Demarcacion.Redemarcacion;
            Objbd.Nombre = Demarcacion.Nombre;
            _db.SaveChanges();
        }
    }
}
