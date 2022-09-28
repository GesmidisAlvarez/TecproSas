using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

// Dominio y persistencia
using  TecproSas.App.Dominio;
using  TecproSas.App.Persistencia;


namespace TecproSas.App.SitioWeb.Pages_Fase
{
    public class ListModel : PageModel
    {
		
		public IEnumerable<Fase> fases {get; set;}
        private IRepositorioFase _repoFase;
		
		public ListModel()
		{
		_repoFase = new RepositorioFase(new TecproSas.App.Persistencia.AppContext());
		}
		
		
        public void OnGet()
        {
			fases = _repoFase.GetALLFase();
        }
    }
}