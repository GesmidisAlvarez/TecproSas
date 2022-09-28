using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

using  TecproSas.App.Dominio;
using  TecproSas.App.Persistencia;

namespace TecproSas.App.SitioWeb.Pages_Proyecto
{
    public class ListModel : PageModel
    {
		
		public IEnumerable<Proyecto> proyectos {get;set;}
		private IRepositorioProyecto _repoProyecto;

		
		public ListModel()
		{			
			_repoProyecto = new RepositorioProyecto(new TecproSas.App.Persistencia.AppContext());	
		}
		
        public void OnGet()
        {
		    proyectos = _repoProyecto.GetALLProyecto();
		}	
		
    }
}
