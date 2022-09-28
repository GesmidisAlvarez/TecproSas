using System.Collections.Generic;  
using TecproSas.App.Dominio;
using System.Linq;


namespace TecproSas.App.Persistencia

{
    public class RepositorioLogin : IRepositorioLogin
    {
        private readonly AppContext _appContext;
        public RepositorioLogin(AppContext appContext)
        {
            _appContext=appContext;
        }

        Login IRepositorioLogin.AddLogin(Login login)
        {
            var loginAdicionado= _appContext.logins.Add(login);
            _appContext.SaveChanges();
            return loginAdicionado.Entity; 
        }
        void IRepositorioLogin.DeleteLogin(int loginId)
        {
            var loginEncontrado = _appContext.logins.FirstOrDefault(l => l.loginId==loginId); 
            if (loginEncontrado == null)
            return;
            _appContext.logins.Remove(loginEncontrado);
            _appContext.SaveChanges(); 
        }
        IEnumerable<Login> IRepositorioLogin.GetALLLogin()
        {
            return _appContext.logins; 
        }
        Login IRepositorioLogin.GetLogin (int loginId)
        {
            return _appContext.logins.FirstOrDefault(l => l.loginId == loginId); 
        }
        Login IRepositorioLogin.UpdateLogin(Login login) 
        {
            var loginEncontrado = _appContext.logins.FirstOrDefault(l => l.loginId == login.loginId); 
            if (loginEncontrado!=null)
            {
                loginEncontrado.usuarioId=login.usuarioId;
                loginEncontrado.clienteId=login.clienteId;
                loginEncontrado.fechaRegistro=login.fechaRegistro;
                loginEncontrado.direccionIp=login.direccionIp;
                
                _appContext.SaveChanges();
            }
            return loginEncontrado;
        }
        
    }
}