using System;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;

namespace TecproSas.App.Dominio
{   public class Fase
    {
        [Key]
        public int faseId { get;set; }
        [MaxLength (60)]
        public string nombreFase { get;set; }
        public DateTime fechaInicioFase{ get;set; }
        [MaxLength (255)]
        public string visitas { get;set; }
        public DateTime fechaVisitas { get;set; }
        [MaxLength (255)]
        public string actualizacionVisita{ get;set; }
    
    //Lista der Proyecto
    public List<Proyecto> proyecto { get;set; }
    
    }
} 