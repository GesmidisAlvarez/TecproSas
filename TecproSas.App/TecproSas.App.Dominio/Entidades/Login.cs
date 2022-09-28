using System;
using System.ComponentModel.DataAnnotations;
namespace TecproSas.App.Dominio
{   public class Login
    {   [Key]
        public int loginId { get;set; }
        public int? usuarioId { get;set; }
        public Usuario usuario {get;set;}
        public int? clienteId { get;set; }
        public Cliente cliente {get;set;}
        public DateTime fechaRegistro { get;set; }
        [MaxLength (60)]
        public string direccionIp { get;set; }
        
    }
} 
