using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WebComputos.AccesoDatos.Data.Repository;
using WebComputos.Models;

namespace WebComputos.AccesoDatos.Data
{
    public class SeccionRepository : Repository<TSeccion>, ISeccionRepository
    {

        private readonly ApplicationDbContext _db;
        public SeccionRepository(ApplicationDbContext db): base(db)
        {
            _db = db;
        }

        public TSeccion Get(object p)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<SelectListItem> GetListaSeccion()
        {
            return _db.TSeccion.Select(i => new SelectListItem()
            {
                Text= i.seccion,
                Value=i.idSeccion.ToString()
            });
        }

        public IEnumerable<SelectListItem> ListaCasillaByMunicipio(int Municipio)
        {
            return _db.TCasillaDet.Where(x => x.Municipio == Municipio).Select(i => new SelectListItem()
            {
                Text = i.Nombre,
                Value = i.IdCasillaDet.ToString()
            }) ;
        }
        public IEnumerable<SelectListItem> ListaCasillaByDistrito(int Municipio, int Distrito)
        {
            var a = (from C in _db.TCasillaDet 
                     join S in _db.TSeccion on C.Seccion equals S.idSeccion
                     where  S.idSeccion == C.Seccion  && C.Municipio == Municipio && S.Distrito == Distrito
                     select new SelectListItem
                     {
                         Text = S.seccion,
                         Value = S.idSeccion.ToString()
                     }).ToList();
            return a;
        }

        public IEnumerable<SelectListItem> ListaCasillaByDemarcacion(int Municipio, int Demarcacion)
        {
            var a = (from C in _db.TCasillaDet
                     join S in _db.TSeccion on C.Seccion equals S.idSeccion
                     where S.idSeccion == C.Seccion && C.Municipio == Municipio && S.Demarcacion == Demarcacion
                     select new SelectListItem
                     {
                         Text = S.seccion,
                         Value = S.idSeccion.ToString()
                     }).ToList();
            return a;
        }

        public IEnumerable<SelectListItem> ListaSeccionByDemarcacion(int Municipio, int Demarcacion)
        {
            return _db.TSeccion.Where(x => x.Municipio == Municipio && x.Demarcacion == Demarcacion).Select(i => new SelectListItem()
            {
                Text = i.seccion,
                Value = i.idSeccion.ToString()
            });
        }

        public IEnumerable<SelectListItem> ListaSeccionByDistrito(int Municipio, int Distrito)
        {
            return _db.TSeccion.Where(x => x.Municipio == Municipio && x.Distrito == Distrito).Select(i => new SelectListItem()
            {
                Text = i.seccion,
                Value = i.idSeccion.ToString()
            });
        }

        public IEnumerable<SelectListItem> ListaSeccionByMunicipio(int Municipio)
        {
            return _db.TSeccion.Where(x => x.Municipio == Municipio).Select(i => new SelectListItem()
            {
                Text = i.seccion,
                Value = i.idSeccion.ToString()
            });
        }

        

        public IEnumerable<SelectListItem> ListaSeccionByMunicipioGob(int Municipio)
        {
            var a = (from D in _db.DetallesActas
                     join C in _db.TCasillaDet on D.IdCasillaDet equals C.IdCasillaDet
                     join S in _db.TSeccion on C.Seccion equals S.idSeccion
                     where D.IdEleccion == 1 && D.Capturado == false && S.idSeccion == C.Seccion && D.IdCasillaDet == C.IdCasillaDet && C.Municipio == Municipio
                     select new SelectListItem
                     {
                         Text = S.seccion,
                         Value = S.idSeccion.ToString()
                     }).Distinct().ToList();
            return a;
        }

        public IEnumerable<SelectListItem> ListaSeccionByMunicipioPys(int Municipio)
        {
            var a = (from D in _db.DetallesActas
                     join C in _db.TCasillaDet on D.IdCasillaDet equals C.IdCasillaDet
                     join S in _db.TSeccion on C.Seccion equals S.idSeccion
                     where D.IdEleccion == 2 && D.Capturado == false && S.idSeccion == C.Seccion && D.IdCasillaDet == C.IdCasillaDet && C.Municipio == Municipio
                     select new SelectListItem
                     {
                         Text = S.seccion,
                         Value = S.idSeccion.ToString()
                     }).Distinct().ToList();
            return a;
        }

        public IEnumerable<SelectListItem> ListaSeccionByMunicipioDip(int Municipio)
        {
            var a = (from D in _db.DetallesActas
                     join C in _db.TCasillaDet on D.IdCasillaDet equals C.IdCasillaDet
                     join S in _db.TSeccion on C.Seccion equals S.idSeccion
                     where D.IdEleccion == 3 && D.Capturado == false && S.idSeccion == C.Seccion && D.IdCasillaDet == C.IdCasillaDet && C.Municipio == Municipio
                     select new SelectListItem
                     {
                         Text = S.seccion,
                         Value = S.idSeccion.ToString()
                     }).Distinct().ToList();
            return a;
        }

        public IEnumerable<SelectListItem> ListaSeccionByMunicipioReg(int Municipio)
        {
            var a = (from D in _db.DetallesActas
                     join C in _db.TCasillaDet on D.IdCasillaDet equals C.IdCasillaDet
                     join S in _db.TSeccion on C.Seccion equals S.idSeccion
                     where D.IdEleccion == 4 && D.Capturado == false && S.idSeccion == C.Seccion && D.IdCasillaDet == C.IdCasillaDet && C.Municipio == Municipio
                     select new SelectListItem
                     {
                         Text = S.seccion,
                         Value = S.idSeccion.ToString()
                     }).Distinct().ToList();
            return a;
        }
        public IEnumerable<SelectListItem> ListaRecepcionByMunicipio(int Municipio)
        {
            var a = (from C in _db.TCasillaDet
                     join R in _db.TRecepcionPaquetes on C.IdCasillaDet equals R.IdCasillaDet into Paquetes
                     from Paq in Paquetes.DefaultIfEmpty()   
                     join S in _db.TSeccion on C.Seccion equals S.idSeccion
                     where S.idSeccion == C.Seccion && C.IdCasillaDet != Paq.IdCasillaDet && C.Municipio == Municipio
                     select new SelectListItem
                     {
                         Text = S.seccion,
                         Value = S.idSeccion.ToString()
                     }).Distinct().ToList();
            return a;
        }


        public void Update(TSeccion seccion)
        {
            var SeccionBD = _db.TSeccion.FirstOrDefault(s => s.idSeccion == seccion.idSeccion);
            SeccionBD.Activo = seccion.Activo;
            SeccionBD.CabLocalidad = seccion.CabLocalidad;
            SeccionBD.Demarcacion = seccion.Demarcacion;
            SeccionBD.Distrito = seccion.Distrito;
            SeccionBD.Municipio = seccion.Municipio;
            SeccionBD.PElectoral = seccion.PElectoral;
            SeccionBD.seccion = seccion.seccion;
            SeccionBD.ListadoNominal = seccion.ListadoNominal;
            _db.SaveChanges();
        }

       
    }
}
