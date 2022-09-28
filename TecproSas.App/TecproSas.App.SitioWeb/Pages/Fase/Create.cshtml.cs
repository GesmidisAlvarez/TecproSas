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

    public class CreateModel: PageModel
    {
        private IRepositorioFase _repoFase{get; set;}
        [BindProperty]
        public Fase fase {get; set;}

        public CreateModel()
        {
		    _repoFase = new RepositorioFase(new TecproSas.App.Persistencia.AppContext());
        }

        public void OnGet()
        {
        }

        public IActionResult OnPost(Fase fase)
        {
            if (ModelState.IsValid)
            {
                _repoFase.AddFase(fase);
                return RedirectToPage("/Fase/List");
            }
            else
            {
                return Page();
            }
            
        }

    }
}

