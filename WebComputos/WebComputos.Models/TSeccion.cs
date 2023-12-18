using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace WebComputos.Models
{
    public class TSeccion
    {
      [Key]
      public int idSeccion { get; set; }
      [Required]
      [Display(Name ="Distrito:")]
      public int? Distrito { get; set; }
      [Required]
      [Display(Name ="Sección:")]
      public string seccion { get; set; }
      [Required]
      [Display(Name ="Demarcación:")]
      public int? Demarcacion { get; set; }
      [Required]
      [Display(Name = "Municipio:")]
      public int? Municipio { get; set; }
      [Required]
      [Display(Name ="Cabecera localidad:")]
      public string CabLocalidad { get; set; }
      [Required]
      [Display(Name ="Listado nominal:")]
      public int ListadoNominal { get; set; }
      [Display(Name ="Activo:")]
      public bool Activo { get; set; }
      [Required]
      [Display(Name ="Padron electoral:")]
      public int PElectoral { get; set; }

      [ForeignKey("Distrito")]
      public TDistrito Ldistrito { get; set; }
      [ForeignKey("Demarcacion")]
      public TDemarcacion Ldemarcacion { get; set; }
      [ForeignKey("Municipio")]
      public TMunicipio Lmunicipio { get; set; }

    }
}
