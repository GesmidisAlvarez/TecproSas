using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using TecproSas.App.Persistencia;
using TecproSas.App.Dominio;

namespace TecproSas.App.SitioWeb.Pages_Cliente
{

    public class CreateModel : PageModel
    {
        private IRepositorioCliente _repoCliente {get; set;}
        [BindProperty]
        public Cliente cliente{get; set;}

        public CreateModel()
        {
		    _repoCliente = new RepositorioCliente(new TecproSas.App.Persistencia.AppContext());
        }

        public void OnGet()
        {   
        }

        public IActionResult OnPost(Cliente cliente)
        {
            if (ModelState.IsValid)
            {
                _repoCliente.AddCliente(cliente);
                return RedirectToPage("/Cliente/List");
            }
            else
            {
                return Page();
            }
            
        }

    }
}
