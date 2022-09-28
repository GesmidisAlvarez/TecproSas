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
    public class DeleteModel : PageModel
    {
        private IRepositorioCliente _repoCliente {get; set;}
        [BindProperty]
        public Cliente cliente {get; set;}

        public DeleteModel()
        {
            _repoCliente = new RepositorioCliente(new TecproSas.App.Persistencia.AppContext());
        }

        public void OnGet(int id)
        {
            cliente = _repoCliente.GetCliente(id);
        }

        public IActionResult OnPost()
        {
            _repoCliente.DeleteCliente(cliente.clienteId);
            return RedirectToPage("/Cliente/List");
        }

    }
}
