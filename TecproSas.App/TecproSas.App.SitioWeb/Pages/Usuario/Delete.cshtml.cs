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
    public class DeleteModel : PageModel
    {
        private IRepositorioUsuario _repoUsuario {get; set;}
        [BindProperty]
        public Usuario usuario {get; set;}

        public DeleteModel()
        {
            _repoUsuario = new RepositorioUsuario(new TecproSas.App.Persistencia.AppContext());
        }

        public void OnGet(int id)
        {
            usuario = _repoUsuario.GetUsuario(id);
        }

        public IActionResult OnPost()
        {
            _repoUsuario.DeleteUsuario(usuario.usuarioId);
            return RedirectToPage("/Usuario/List");
        }

    }
}