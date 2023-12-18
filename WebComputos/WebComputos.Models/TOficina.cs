using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace WebComputos.Models
{
    public class TOficina
    {
        [Key]
        public int IdOficina { get; set; }
        [Required(ErrorMessage = "El nombre es requerido")]
        [Display(Name = "Nombre:")]
        public string Nom_Ofi { get; set; }
        [Required(ErrorMessage = "Las siglas son requeridas")]
        [Display(Name = "Siglas:")]
        public string Siglas_Ofi { get; set; }
        [Required(ErrorMessage = "La calle es requerida")]
        [Display(Name = "Calle:")]
        public string Calle { get; set; }
        [Required(ErrorMessage = "El no.exterior es requerido")]
        [Display(Name = "No.Exterior:")]
        public string NoExterior { get; set; }

        [Display(Name = "No.Interior:")]
        public string NoInterior { get; set; }
        [Required(ErrorMessage = "La colonia es requerida")]
        [Display(Name = "Colonia:")]
        public string Colonia { get; set; }
        [Required(ErrorMessage = "El municipio es requerido")]
        [Display(Name = "Municipio:")]
        public int Municipio { get; set; }
        [Required(ErrorMessage = "El codigo postal es requerido")]
        [Display(Name = "C.P.:")]
        public int CodigoPostal { get; set; }
        [Display(Name = "Telefono 1:")]
        public string Telefono1 { get; set; }
        [Display(Name = "Telefono 2:")]
        public string Telefono2 { get; set; }
        [Display(Name = "Responsable")]
        public string idTrabajador { get; set; }

        [ForeignKey("Municipio")]
        public TMunicipio Lmunicipio { get; set; }


    }
}
