using System;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;
namespace TecproSas.App.Dominio

{
    public class Usuario
    {
        [Key]
        public int usuarioId { get;set; }
        
        [MaxLength (60)]
        public string nombre { get;set; }
        [MaxLength (60)]
        public string apellidos { get;set; }
        [MaxLength (20)]
        public string direccion { get;set; }
        public Rol rol { get;set; }
        public Estado estado { get;set; }
        [MaxLength (20)]
        public string nicknname { get;set; }
        [MaxLength (20)]
        public string contrasenia { get;set; }

        //lista de Proyecto
        public List<Proyecto> listProyec { get;set; }
    }
}