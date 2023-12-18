using System;
using System.Collections.Generic;
using System.Text;
using WebComputos.AccesoDatos.Data.Repository;
using WebComputos.Models;

namespace WebComputos.AccesoDatos.Data
{
    public class ContenedorTrabajo : IContenedorTrabajo
    {
        private readonly ApplicationDbContext _db;

        public ContenedorTrabajo(ApplicationDbContext db)
        {
            _db = db;
            Acta = new ActasRepository(_db);
            Distrito = new DistritoRepository(_db);
            Municipio = new MunicipioRepository(_db);
            Demarcacion = new DemarcacionRepository(_db);
            Seccion = new SeccionRepository(_db);
            TipoEleccion = new TipoEleccionReporisoty(_db);
            TipoCasilla = new TipoCasillaRepository(_db);
            TipoActa = new TipoActaRepository(_db);
            CasillaDet = new CasillaDetRepository(_db);
            Coalicion = new CoalicionRepository(_db);
            Partido = new PartidosRepository(_db);
            CoalicionDet = new CoalicionDetRepository(_db);
            Candidato = new CandidatoRepository(_db);
            Recepcion = new RecepcionPaquetesRepository(_db);
            ResActas = new TResultadosActasRepository(_db);
            Combinacion = new CombinacionesRepository(_db);
            CombinacionesDet = new CombinacinesdetRepository(_db);
            RecepcionDetalle = new RecepcionDetalleRepository(_db);
            EstatusActa = new EstatusActaRepository(_db);
            Causales = new CausalesRepository(_db);
            ApplicationUser = new ApplicationUserRepository(_db);
            Oficina = new OficinaRepository(_db);



        }
        public IActasRepository Acta { get; private set; }
        public IDistritoReporitory Distrito { get; private set; }
        public IMunicipioRepository Municipio { get; private set; }
        public IDemarcacionRepository Demarcacion { get; private set; }
        public ISeccionRepository Seccion { get; private set; }
        public ICatEleccionRepository TipoEleccion { get; private set; }
        public ItipoCasillaRepository TipoCasilla { get; private set; }
        public ITipoActaRepository TipoActa { get; private set; }
        public ICasillaDetRepository CasillaDet { get; private set; }
        public ICoalicionRepository Coalicion { get; private set; }
        public IPartidoRepository Partido { get; private set; }
        public IcoalicionDetRepository CoalicionDet { get; private set; }
        public ICandidatoRepository Candidato { get; private set; }
        public IRecepcionRepository Recepcion { get; private set; }
        public IResultadosActasRepository ResActas { get; private set; }

        public IOficina Oficina { get; private set; }
        
        public ICombinacionesDetRepository CombinacionesDet { get; private set; }

        public ICombinacionesRepository Combinacion { get; private set; }
        public IRecepcionDetalleRepository RecepcionDetalle { get; private set; }
        public IEstatusActaRepository EstatusActa { get; private set; }

        public IApplicationUserRepository ApplicationUser { get; private set; }
        public ICausalesRepository Causales { get; private set; }

        public void Dispose()
        {
            _db.Dispose();
        }

        public void Save()
        {
            _db.SaveChanges();
        }
    }
}
