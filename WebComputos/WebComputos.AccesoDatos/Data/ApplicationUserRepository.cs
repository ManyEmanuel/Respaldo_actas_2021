using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WebComputos.AccesoDatos.Data.Repository;
using WebComputos.Models;

namespace WebComputos.AccesoDatos.Data
{
    class ApplicationUserRepository : Repository<ApplicationUser>, IApplicationUserRepository
    {
        private ApplicationDbContext _db;

        public ApplicationUserRepository(ApplicationDbContext db): base(db)
        {
            _db = db;
        }
        public IEnumerable<SelectListItem> GetListaUsuarios()
        {
            return _db.ApplicationUser.Select(i => new SelectListItem()
            {
                Text = (i.Nombres + " " + i.ApellidoPat + " " + i.ApellidoMat),
                Value = i.Id
            });
        }

        public void Update(ApplicationUser user)
        {
            var Obj = _db.ApplicationUser.Find(user.Id);
            Obj.Nombres = user.Nombres;
            Obj.ApellidoPat = user.ApellidoPat;
            Obj.ApellidoMat = user.ApellidoMat;
            Obj.Email = user.Email;
            if (user.FotoURL != null)
            {
                Obj.FotoURL = user.FotoURL;
            }
            Obj.IdOficina = user.IdOficina;
            Obj.UserName = user.UserName;
            Obj.PasswordHash = user.PasswordHash;
        }
    }
}
