using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WebComputos.AccesoDatos.Data.Repository;
using WebComputos.Models;

namespace WebComputos.AccesoDatos.Data
{
    class OficinaRepository : Repository<TOficina>, IOficina
    {
        private ApplicationDbContext _db;

        public OficinaRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }

        public IEnumerable<SelectListItem> GetListaOficina()
        {
            return _db.TOficina.Select(i => new SelectListItem()
            {
                Text = (i.Nom_Ofi),
                Value = i.IdOficina.ToString()
            });
        }

        public void Update(TOficina Oficina)
        {
            var Objbd = _db.TOficina.FirstOrDefault(s => s.IdOficina == Oficina.IdOficina);
            Objbd.Calle = Oficina.Calle;
            Objbd.CodigoPostal = Oficina.CodigoPostal;
            Objbd.Colonia = Oficina.Colonia;
            Objbd.idTrabajador = Oficina.idTrabajador;
            Objbd.Municipio = Oficina.Municipio;
            Objbd.NoExterior = Oficina.NoExterior;
            Objbd.NoInterior = Oficina.NoInterior;
            Objbd.Nom_Ofi = Oficina.Nom_Ofi;
            Objbd.Siglas_Ofi = Oficina.Siglas_Ofi;
            Objbd.Telefono1 = Oficina.Telefono1;
            Objbd.Telefono2 = Oficina.Telefono2;
        }
    }
}
