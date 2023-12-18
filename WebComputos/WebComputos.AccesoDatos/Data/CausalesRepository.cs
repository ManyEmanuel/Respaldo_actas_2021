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


namespace WebComputos.AccesoDatos.Data
{
    public class CausalesRepository : Repository<Causales>, ICausalesRepository

    {
        private readonly ApplicationDbContext _db;
        public CausalesRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }

        public IEnumerable<ElementosListas> GetListaGobernador(int mun)
        {

            List<ElementosListas> lstda = new List<ElementosListas>();
            lstda = (
                    from d in _db.TCasillaDet
                    join e in _db.Causales on d.IdCasillaDet equals e.IdCasillaDet
                    join s in _db.TSeccion on d.Seccion equals s.idSeccion
                    where s.idSeccion == d.Seccion && e.IdEleccion == 1 && s.Municipio == mun

                    select new ElementosListas
                    {
                        idr = d.TipoCasilla,
                        seccion = s.seccion,
                        casilla = d.Nombre,
                        cau1 = e.PaqSinAec,
                        cau2 = e.VotosNMayor,
                        cau3 = e.VotosSisBol,
                        cau4 = e.VotosSisAec,
                        cau5 = e.VotosPartido,
                        cau6 = e.ActaIlegible,
                        cau7 = e.ActAlteraciones,
                        cau8 = e.PaqAlteraciones,
                        cau9 = e.CiuVotaron,
                        cau10 = e.BoletasSisCiu,
                        cau11 = e.BoletasSisTot,
                        numcau = e.NumCausales
                    }).OrderBy(x=> x.seccion).ThenBy(x=> x.idr).ToList();
            return lstda;
          
        }

        public IEnumerable<ElementosListas> GetListaPys(int mun)
        {

            List<ElementosListas> lstda = new List<ElementosListas>();
            lstda = (
                    from d in _db.TCasillaDet
                    join e in _db.Causales on d.IdCasillaDet equals e.IdCasillaDet
                    join s in _db.TSeccion on d.Seccion equals s.idSeccion
                    where s.idSeccion == d.Seccion && e.IdEleccion == 2 && s.Municipio == mun

                    select new ElementosListas
                    {
                        idr = d.TipoCasilla,
                        seccion = s.seccion,
                        casilla = d.Nombre,
                        cau1 = e.PaqSinAec,
                        cau2 = e.VotosNMayor,
                        cau3 = e.VotosSisBol,
                        cau4 = e.VotosSisAec,
                        cau5 = e.VotosPartido,
                        cau6 = e.ActaIlegible,
                        cau7 = e.ActAlteraciones,
                        cau8 = e.PaqAlteraciones,
                        cau9 = e.CiuVotaron,
                        cau10 = e.BoletasSisCiu,
                        cau11 = e.BoletasSisTot,
                        numcau = e.NumCausales
                    }).OrderBy(x => x.seccion).ThenBy(x => x.idr).ToList();
            return lstda;

        }
        public IEnumerable<ElementosListas> GetListaDip(int mun)
        {

            List<ElementosListas> lstda = new List<ElementosListas>();
            lstda = (
                    from d in _db.TCasillaDet
                    join e in _db.Causales on d.IdCasillaDet equals e.IdCasillaDet
                    join s in _db.TSeccion on d.Seccion equals s.idSeccion
                    where s.idSeccion == d.Seccion && e.IdEleccion == 3 && s.Municipio == mun

                    select new ElementosListas
                    {
                        idr = d.TipoCasilla,
                        seccion = s.seccion,
                        casilla = d.Nombre,
                        cau1 = e.PaqSinAec,
                        cau2 = e.VotosNMayor,
                        cau3 = e.VotosSisBol,
                        cau4 = e.VotosSisAec,
                        cau5 = e.VotosPartido,
                        cau6 = e.ActaIlegible,
                        cau7 = e.ActAlteraciones,
                        cau8 = e.PaqAlteraciones,
                        cau9 = e.CiuVotaron,
                        cau10 = e.BoletasSisCiu,
                        cau11 = e.BoletasSisTot,
                        numcau = e.NumCausales,
                        Distrito = s.Distrito
                    }).OrderBy(x => x.seccion).ThenBy(x => x.idr).ToList();
            return lstda;

        }
        public IEnumerable<ElementosListas> GetListaReg(int mun)
        {

            List<ElementosListas> lstda = new List<ElementosListas>();
            lstda = (
                    from d in _db.TCasillaDet
                    join e in _db.Causales on d.IdCasillaDet equals e.IdCasillaDet
                    join s in _db.TSeccion on d.Seccion equals s.idSeccion
                    where s.idSeccion == d.Seccion && e.IdEleccion == 4 && s.Municipio == mun

                    select new ElementosListas
                    {
                        idr = d.TipoCasilla,
                        seccion = s.seccion,
                        casilla = d.Nombre,
                        cau1 = e.PaqSinAec,
                        cau2 = e.VotosNMayor,
                        cau3 = e.VotosSisBol,
                        cau4 = e.VotosSisAec,
                        cau5 = e.VotosPartido,
                        cau6 = e.ActaIlegible,
                        cau7 = e.ActAlteraciones,
                        cau8 = e.PaqAlteraciones,
                        cau9 = e.CiuVotaron,
                        cau10 = e.BoletasSisCiu,
                        cau11 = e.BoletasSisTot,
                        numcau = e.NumCausales,
                        Demarcacion = s.Demarcacion
                    }).OrderBy(x => x.seccion).ThenBy(x => x.idr).ToList();
            return lstda;

        }



    } 

}
