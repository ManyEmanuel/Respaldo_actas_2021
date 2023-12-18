using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Text;
using WebComputos.Models;

namespace WebComputos.AccesoDatos.Data.Repository
{
    public interface ISeccionRepository : IRepositor<TSeccion> 
    {
        IEnumerable<SelectListItem> GetListaSeccion();
        IEnumerable<SelectListItem>ListaSeccionByMunicipio(int Municipio);
        IEnumerable<SelectListItem> ListaRecepcionByMunicipio(int Municipio);
        IEnumerable<SelectListItem> ListaSeccionByMunicipioGob(int Municipio);
        IEnumerable<SelectListItem> ListaSeccionByMunicipioPys(int Municipio);
        IEnumerable<SelectListItem> ListaSeccionByMunicipioDip(int Municipio);
        IEnumerable<SelectListItem> ListaSeccionByMunicipioReg(int Municipio);
        IEnumerable<SelectListItem> ListaCasillaByMunicipio(int Municipio);
        IEnumerable<SelectListItem> ListaCasillaByDistrito(int Municipio, int Distrito);
        IEnumerable<SelectListItem> ListaCasillaByDemarcacion(int Municipio, int Demarcacion);

        IEnumerable<SelectListItem> ListaSeccionByDistrito(int Municipio, int Distrito);
        IEnumerable<SelectListItem> ListaSeccionByDemarcacion(int Municipio, int Demarcacion);

        void Update(TSeccion seccion);
       
    }
}
