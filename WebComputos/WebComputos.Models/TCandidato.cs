using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace WebComputos.Models
{
    public class TCandidato
    {
        [Key]
        public int IdCandidato { get; set; }
        [Required(ErrorMessage ="los nombres del candidato son obligatorios")]
        public string Nombres { get; set; }
        [Required(ErrorMessage ="El apellido Paterno es obligatorio")]
        public string ApellidoPat { get; set; }
        [Required(ErrorMessage ="El apellido materno es obligatorio")]
        public string ApellidoMat { get; set; }
        public string Mote { get; set; }
        [Required]
        public int TipoEleccion { get; set; }
        [Required]
        public int Municipio { get; set; }
        [Required]
        public int Distrito { get; set; }
        [Required]
        public int Demarcacion { get; set; }
        [Required]
        public int Estado { get; set; }
        public int? Coalicion { get; set; }
        [Required]
        public int Partido { get; set; }
        public int Orden { get; set; }
        public bool EsCoalicion { get; set; }
        public bool Activo { get; set; }

        [ForeignKey("TipoEleccion")]
        public TtipoEleccion LTipoEleccion { get; set; }
        [ForeignKey("Municipio")]
        public TMunicipio LMunicipio { get; set; }
        [ForeignKey("Distrito")]
        public TDistrito LDistrito { get; set; }
        [ForeignKey("Demarcacion")]
        public TDemarcacion LDemarcacion { get; set; }
        [ForeignKey("Coalicion")]
        public TCoalicion LCoalicion { get; set; }
        [ForeignKey("Partido")]
        public TPartidos LPartido { get; set; }


    }
}
