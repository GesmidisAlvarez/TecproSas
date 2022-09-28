using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using TecproSas.App.Persistencia;
using TecproSas.App.Dominio;

namespace TecproSas.App.SitioWeb.Pages_Servicio
{
    public class CreateModel : PageModel
    {
        private IRepositorioServicio _repoServicio {get; set;}
        [BindProperty]
        public Servicio servicio {get; set;}

        public CreateModel()
        {
		    _repoServicio = new RepositorioServicio(new TecproSas.App.Persistencia.AppContext());
        }

        public void OnGet()
        {
        }

        public IActionResult OnPost(Servicio servicio)
        {
            if (ModelState.IsValid)
            {
                _repoServicio.AddServicio(servicio);
                return RedirectToPage("/Servicio/List");
            }
            else
            {
                return Page();
            }
            
        }

    }
}