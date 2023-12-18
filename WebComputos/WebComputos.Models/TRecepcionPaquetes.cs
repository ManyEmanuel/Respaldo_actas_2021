using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace WebComputos.Models
{
    public class TRecepcionPaquetes
    {
        [Key]
        public int IdRecepcion { get; set; }

        [Display(Name = "Hora de recepción:")]
        public DateTime Hora { get; set; }

        [Display(Name = "Fecha de recepción:")]
        public DateTime Fecha { get; set; }
        public DateTime HoraReg { get; set; }
        public DateTime FechaReg { get; set; }

        [Display(Name = "Persona que hace entrega del paquete electoral:")]
        public string Entrega  { get; set; }

        [Display(Name = "Cargo/Puesto de quien entrega:")]
        public string Cargo { get; set; }
        public string Observaciones { get; set; }

        public int SobrePrep { get; set; }
        public int PaqueteElec { get; set; }
        public bool Capturado { get; set; }
        public int IdCasillaDet { get; set; }
        
        [ForeignKey("IdCasillaDet")]
        public TCasillaDet LCasillaDet { get; set; }



    }
}
