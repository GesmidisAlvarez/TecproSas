using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using TecproSas.App.Persistencia;
using TecproSas.App.Dominio;

namespace TecproSas.App.SitioWeb.Pages_Usuario
{
    public class EditModel : PageModel
    {
        private IRepositorioUsuario _repoUsuario {get; set;}
        [BindProperty]
        public Usuario usuario {get; set;}

        public EditModel()
        {
            _repoUsuario = new RepositorioUsuario(new TecproSas.App.Persistencia.AppContext());
        }

        public IActionResult OnGet(int id)
        {
            usuario = _repoUsuario.GetUsuario(id);
            if (usuario== null)
            {
                return RedirectToPage("/Usuario/List");
            }
            else
            {
                return Page();
            }
        }


        public IActionResult OnPost(Usuario usuario)
        {
            _repoUsuario.UpdateUsuario(usuario);
            return RedirectToPage("/Usuario/List");
        }
    }
}
