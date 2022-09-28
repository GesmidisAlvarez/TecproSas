using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

// Dominio y persistencia
using  TecproSas.App.Dominio;
using  TecproSas.App.Persistencia;

namespace TecproSas.App.SitioWeb.Pages_Login
{
    public class ListModel: PageModel
    {
        public IEnumerable<Login> logins {get;set;}
        private IRepositorioLogin _repoLogin;
		
		public ListModel()
		{			
		    _repoLogin = new RepositorioLogin(new TecproSas.App.Persistencia.AppContext());		
		}
		
		
        public void OnGet()
        {
			logins = _repoLogin.GetALLLogin();
        }

    }
}
