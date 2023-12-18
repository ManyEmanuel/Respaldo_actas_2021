using System;
using Microsoft.AspNetCore.Mvc.Rendering;
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
    public class RecepcionPaquetesRepository : Repository<TRecepcionPaquetes>, IRecepcionRepository
    {
        private readonly ApplicationDbContext _db;

        public RecepcionPaquetesRepository(ApplicationDbContext db): base(db)
        {
            _db = db;
        }

        public TRecepcionPaquetes Get(object p)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<ElementosListas> GetListaPaquetesByMun(int mun)
        {
            List<ElementosListas> lstda = new List<ElementosListas>();
            lstda = (from r in _db.TRecepcionPaquetes
                     join d in _db.TCasillaDet on r.IdCasillaDet equals d.IdCasillaDet
                     join s in _db.TSeccion on d.Seccion equals s.idSeccion
                     join c in _db.TtipoCasilla on d.TipoCasilla equals c.IdTipoCasilla
                     where r.IdCasillaDet == d.IdCasillaDet && s.idSeccion == d.Seccion && c.IdTipoCasilla == d.TipoCasilla && s.Municipio == mun

                     select new ElementosListas
                     {
                         seccion = s.seccion,
                         casilla = d.Nombre,
                         recep = r.Hora,
                         idr = r.IdRecepcion
                     }).ToList();
            return lstda;
        }

        public IEnumerable<SelectListItem> GetListaRecepcion()
        {
            return _db.TRecepcionPaquetes.Select(i => new SelectListItem()
            {
                Text = i.Cargo,
                Value = i.IdRecepcion.ToString()
            }
            );
        }










    }
}
