using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using WebComputos.Models;

namespace WebComputos.AccesoDatos.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<TSeccion> TSeccion { get; set; }
        public DbSet<TDistrito> TDistrito { get; set; }
        public DbSet<TMunicipio> TMunicipio { get; set; }
        public DbSet<TDemarcacion> TDemarcacion { get; set; }
        public DbSet<TtipoEleccion> TtipoEleccion { get; set; }
        public DbSet<TtipoCasilla> TtipoCasilla { get; set; }
        public DbSet<TtipoActa> TtipoActa { get; set; }
        public DbSet<TCasillaDet> TCasillaDet { get; set; }
        public DbSet<TPartidos> TPartido { get; set; }
        public DbSet<TCoalicion> TCoalicion { get; set; }
        public DbSet<TCoalicionDet> TCoaliciondet { get; set; }
        public DbSet<TCandidato> TCandidato { get; set; }
        public DbSet<TRecepcionPaquetes> TRecepcionPaquetes { get; set; }
        public DbSet<TActas> TActas { get; set; }
        public DbSet<TResultadosActas> TResultadosActas { get; set; }
        public DbSet<Combinaciones> Combinaciones { get; set; }
        public DbSet<CombinacionesDet> CombinacionesDet { get; set; }
        public DbSet<ResultadoComputos> ResCom { get; set; }
        public DbSet<RecepcionDetalle> RecepcionDetalle { get; set; }
        public DbSet<EstatusActa> EstatusActas { get; set; }
        public DbSet<DetallesActas> DetallesActas { get; set; }
        public DbSet<ApplicationUser> ApplicationUser { get; set; }
        public DbSet<Causales> Causales { get; set; }
        public DbSet<EstatusEntrega> EstatusEntregas { get; set; }
        public DbSet<TOficina> TOficina { get; set; }


    }
}
