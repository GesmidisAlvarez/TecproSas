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
    public class EditModel : PageModel
    {
        private IRepositorioCliente _repoCliente {get; set;}
        [BindProperty]
        public Cliente cliente {get; set;}

        public EditModel()
        {
            _repoCliente = new RepositorioCliente(new TecproSas.App.Persistencia.AppContext());
        }

        public IActionResult OnGet(int id)
        {
            cliente = _repoCliente.GetCliente(id);
            if (cliente == null)
            {
                return RedirectToPage("/Cliente/List");
            }
            else
            {
                return Page();
            }
        }


        public IActionResult OnPost(Cliente cliente)
        {
            _repoCliente.UpdateCliente(cliente);
            return RedirectToPage("/Cliente/List");
        }
    }
}
