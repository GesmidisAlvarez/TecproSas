using System;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;
namespace TecproSas.App.Dominio
{   public class Cliente
    {
        [Key]
        public int clienteId { get;set; }

        [MaxLength (20)]
        public string nit{ get;set; }
        [MaxLength (60)]
        public string nombre { get;set; }
         [MaxLength (80)]
        public string apellidos { get;set; }
         [MaxLength (15)]
        public string telefono { get;set; }
         [MaxLength (40)]
        public string nacionalidad { get;set; }
         [MaxLength (60)]
        public string email { get;set; }
         [MaxLength (60)]
        public string direccionCliente{ get;set; }
    
        
    
    //lista de Casos
    public List<Proyecto> proyecto { get;set; }
    
    
    }
} 