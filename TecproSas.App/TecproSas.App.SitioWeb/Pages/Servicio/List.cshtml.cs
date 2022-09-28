using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

// Dominio y persistencia
using  TecproSas.App.Dominio;
using  TecproSas.App.Persistencia;


namespace TecproSas.App.SitioWeb.Pages_Servicio
{
    public class ListModel : PageModel
    {
		
		public IEnumerable<Servicio> servicios {get;set;}
        private IRepositorioServicio _repoServicio;
		
		public ListModel()
		{
			_repoServicio = new RepositorioServicio(new TecproSas.App.Persistencia.AppContext());	
		}
		
		
        public void OnGet()
        {
			servicios = _repoServicio.GetALLServicio();	
        }
    }
}
