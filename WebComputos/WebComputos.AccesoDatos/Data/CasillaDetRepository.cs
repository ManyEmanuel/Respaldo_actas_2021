using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WebComputos.AccesoDatos.Data.Repository;
using WebComputos.Models;

namespace WebComputos.AccesoDatos.Data
{
    public class CasillaDetRepository : Repository<TCasillaDet>, ICasillaDetRepository
    {
        private ApplicationDbContext _db;

        public CasillaDetRepository(ApplicationDbContext db): base(db)
        {
            _db = db;
        }

        public IEnumerable<SelectListItem> GetListaTipoCasilla()
        {
            return _db.TCasillaDet.Select(i => new SelectListItem()
            {
                Text = i.NoCasilla.ToString(),
                Value = i.IdCasillaDet.ToString()
            });
        }
              
        public void Update(TCasillaDet CasillaDet)
        {
            var ObjBd = _db.TCasillaDet.FirstOrDefault(s => s.IdCasillaDet == CasillaDet.IdCasillaDet);
            ObjBd.Activo = CasillaDet.Activo;
            ObjBd.ExtContigua = CasillaDet.ExtContigua;
            ObjBd.ListadoNominal = CasillaDet.ListadoNominal;
            ObjBd.Seccion = CasillaDet.Seccion;
            ObjBd.TipoCasilla = CasillaDet.TipoCasilla;
            ObjBd.Nombre = CasillaDet.Nombre;
            ObjBd.Capturado = CasillaDet.Capturado;
           
        }
    }
}
