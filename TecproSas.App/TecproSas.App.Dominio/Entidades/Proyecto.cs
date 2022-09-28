using System;
using System.ComponentModel.DataAnnotations;
namespace TecproSas.App.Dominio
{   public class Proyecto
    {   [Key]
        public int proyectoId { get;set; }

        public int? clienteId {get;set;}
        public Cliente cliente {get;set;}

        public int? servicioId {get;set;}
        public Servicio servicio {get;set;}

        public int? faseId {get;set;}
        public Fase fase {get;set;}

        [MaxLength (60)]
        public string nombre { get;set; }
        [MaxLength (60)]
        public string aprobadoPor { get;set; }
        [MaxLength (255)]
        public string descripcion { get;set; }
        public DateTime fechaInicio { get;set; }
        public int presupuesto { get;set; }
        public DateTime tiempoEjecucion { get;set; }
        public int faseActual { get;set; }
        
    }
} 