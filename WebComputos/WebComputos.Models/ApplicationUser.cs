using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace WebComputos.Models
{
    public class ApplicationUser : IdentityUser
    {
        [Required(ErrorMessage = "El nombre del usuario es requerido")]
        [Display(Name = "Nombre:")]
        public string Nombres { get; set; }

        [Required(ErrorMessage = "El apellido paterno es requerido")]
        [Display(Name = "Apellido paterno:")]
        public string ApellidoPat { get; set; }

        [Display(Name = "Apellido materno:")]
        public string ApellidoMat { get; set; }

        [Display(Name = "Fotografia")]
        public string FotoURL { get; set; }
        [Display(Name = "Oficina:")]
        [Required(ErrorMessage = "La oficina es requerida")]
        public int IdOficina { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "El {0} debe ser al menos de {2} y maximo {1} de caracteres de longitud.", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "Contraseña")]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Confirmar contraseña")]
        [Compare("Password", ErrorMessage = "Las contraseñas no coinciden.")]
        public string ConfirmedPassword { get; set; }

        [ForeignKey("IdOficina")]
        public TOficina Loficina { get; set; }

    }
}
