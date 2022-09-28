using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;


using TecproSas.App.Dominio;
using TecproSas.App.Persistencia;


namespace TecproSas.App.SitioWeb.Pages_Usuario
{
    public class ListModel: PageModel
    {
		
		public IEnumerable<Usuario> usuarios {get;set;}
        private IRepositorioUsuario _repoUsuario;
		
		public ListModel()
		{
			
		   _repoUsuario = new RepositorioUsuario(new TecproSas.App.Persistencia.AppContext());
			
		}
		
		
        public void OnGet()
        {
			usuarios = _repoUsuario.GetALLUsuario();
	
        }
    }
}