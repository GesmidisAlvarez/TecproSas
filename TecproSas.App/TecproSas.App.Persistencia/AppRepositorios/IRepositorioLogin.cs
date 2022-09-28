using System.Collections.Generic;  
using TecproSas.App.Dominio;

namespace TecproSas.App.Persistencia
{

    public interface IRepositorioLogin
    {
        IEnumerable <Login> GetALLLogin();  
        Login AddLogin(Login login);
        Login UpdateLogin(Login login);
        void DeleteLogin(int loginId);
        Login GetLogin(int loginId);
    }
    
}