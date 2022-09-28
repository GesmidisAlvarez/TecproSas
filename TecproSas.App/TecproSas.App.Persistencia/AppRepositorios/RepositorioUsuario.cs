using System.Collections.Generic;  
using TecproSas.App.Dominio;
using System.Linq;


namespace TecproSas.App.Persistencia

{
    public class RepositorioUsuario : IRepositorioUsuario
    {
        private readonly AppContext _appContext;
        public RepositorioUsuario(AppContext appContext)
        {
            _appContext=appContext;
        }

        Usuario IRepositorioUsuario.AddUsuario(Usuario usuario)
        {
            var usuarioAdicionado= _appContext.usuarios.Add(usuario);
            _appContext.SaveChanges();
            return usuarioAdicionado.Entity; 
        }
        void IRepositorioUsuario.DeleteUsuario(int usuarioId)
        {
            var usuarioEncontrado = _appContext.usuarios.FirstOrDefault(u => u.usuarioId==usuarioId); 
            if (usuarioEncontrado == null)
            return;
            _appContext.usuarios.Remove(usuarioEncontrado);
            _appContext.SaveChanges(); 
        }
        IEnumerable<Usuario> IRepositorioUsuario.GetALLUsuario()
        {
            return _appContext.usuarios; 
        }
        Usuario IRepositorioUsuario.GetUsuario (int usuarioId)
        {
            return _appContext.usuarios.FirstOrDefault(u => u.usuarioId == usuarioId); 
        }
        Usuario IRepositorioUsuario.UpdateUsuario(Usuario usuario) 
        {
            var usuarioEncontrado = _appContext.usuarios.FirstOrDefault(u => u.usuarioId == usuario.usuarioId); 
            if (usuarioEncontrado!=null)
            {
                
                usuarioEncontrado.nombre=usuario.nombre;
                usuarioEncontrado.apellidos=usuario.apellidos;
                usuarioEncontrado.direccion=usuario.direccion;
                usuarioEncontrado.rol=usuario.rol;
                usuarioEncontrado.estado=usuario.estado;
                usuarioEncontrado.nicknname=usuario.nicknname;
                usuarioEncontrado.contrasenia=usuario.contrasenia;
        
                
                _appContext.SaveChanges();
            }
            return usuarioEncontrado;
        }
        
    }
}