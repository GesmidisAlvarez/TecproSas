using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

// Dominio y persistencia
using  TecproSas.App.Dominio;
using  TecproSas.App.Persistencia;

namespace TecproSas.App.SitioWeb.Pages_Cliente
{
    public class ListModel : PageModel
    {	
        public IEnumerable<Cliente> clientes {get; set;}
        private IRepositorioCliente _repoCliente;
		
		public ListModel()

		{
			_repoCliente = new RepositorioCliente(new TecproSas.App.Persistencia.AppContext());
			
		}

        public void OnGet()
        {
            clientes = _repoCliente.GetALLCliente();
        }
    }
}
