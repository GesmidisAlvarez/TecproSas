using System.Collections.Generic;  
using TecproSas.App.Dominio;

namespace TecproSas.App.Persistencia
{

    public interface IRepositorioUsuario
    {
        IEnumerable <Usuario> GetALLUsuario();  
        Usuario AddUsuario(Usuario usuario);
        Usuario UpdateUsuario(Usuario usuario);
        void DeleteUsuario(int usuarioId);
        Usuario GetUsuario(int usuarioId);
    }
    
}