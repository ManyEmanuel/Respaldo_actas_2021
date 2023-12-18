using System;
using System.Collections.Generic;
using System.Text;

namespace WebComputos.AccesoDatos.Data.Repository
{
    public interface IContenedorTrabajo : IDisposable
    {
        IDistritoReporitory Distrito { get; }
        IMunicipioRepository Municipio { get; }
        IDemarcacionRepository Demarcacion { get; }
        ISeccionRepository Seccion { get; }
        ICatEleccionRepository TipoEleccion { get; }
        ItipoCasillaRepository TipoCasilla { get; }
        ITipoActaRepository TipoActa { get; }
        ICasillaDetRepository CasillaDet { get; }
        ICoalicionRepository Coalicion { get; }
        IPartidoRepository Partido { get; }
        IcoalicionDetRepository CoalicionDet { get; }
        ICandidatoRepository Candidato { get; }
        IRecepcionRepository Recepcion { get; }
        IActasRepository Acta { get; }
        
        IApplicationUserRepository  ApplicationUser { get; }
        IResultadosActasRepository ResActas { get; }
        ICombinacionesRepository Combinacion { get; }
        ICombinacionesDetRepository CombinacionesDet { get; }
        IEstatusActaRepository EstatusActa { get; }
        ICausalesRepository Causales { get; }
        IOficina Oficina { get; }
        void Save();
    }
}
