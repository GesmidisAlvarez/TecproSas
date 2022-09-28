using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using TecproSas.App.Persistencia;
using TecproSas.App.Dominio;

namespace TecproSas.App.SitioWeb.Pages_Fase
{
    public class DeleteModel : PageModel
    {
        private IRepositorioFase _repoFase {get; set;}
        [BindProperty]
        public Fase fase {get; set;}

        public DeleteModel()
        {
            _repoFase = new RepositorioFase(new TecproSas.App.Persistencia.AppContext());
        }

        public void OnGet(int id)
        {
            fase = _repoFase.GetFase(id);
        }

        public IActionResult OnPost()
        {
            _repoFase.DeleteFase(fase.faseId);
            return RedirectToPage("/Fase/List");
        }

    }
}