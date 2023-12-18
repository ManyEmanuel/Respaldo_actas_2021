using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WebComputos.AccesoDatos.Data.Repository;
using WebComputos.Models;

namespace WebComputos.AccesoDatos.Data
{
    public class CandidatoRepository : Repository<TCandidato>, ICandidatoRepository
    {
        private ApplicationDbContext _db;
        public CandidatoRepository(ApplicationDbContext db): base(db)
        {
            _db = db;
        }

        public IEnumerable<SelectListItem> GetListaCandidato()
        {
            return _db.TCandidato.Select(i => new SelectListItem()
            {
                Text = (i.Nombres + " " + i.ApellidoPat).ToString(),
                Value = i.IdCandidato.ToString()
            });
        }

        public void Update(TCandidato Candidato)
        {
            var Objbd = _db.TCandidato.FirstOrDefault(s => s.IdCandidato == Candidato.IdCandidato);
            Objbd.Activo = Candidato.Activo;
            Objbd.ApellidoMat = Candidato.ApellidoMat;
            Objbd.ApellidoPat = Candidato.ApellidoPat;
            Objbd.Coalicion = Candidato.Coalicion;
            Objbd.Demarcacion = Candidato.Demarcacion;
            Objbd.Distrito = Candidato.Distrito;
            Objbd.EsCoalicion = Candidato.EsCoalicion;
            Objbd.Estado = Candidato.Estado;
            Objbd.Mote = Candidato.Mote;
            Objbd.Municipio = Candidato.Municipio;
            Objbd.Nombres = Candidato.Nombres;
            Objbd.Orden = Candidato.Orden;
            Objbd.Partido = Candidato.Partido;
            Objbd.TipoEleccion = Candidato.TipoEleccion;
        }
    }
}
