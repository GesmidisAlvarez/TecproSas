using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using TecproSas.App.Persistencia;
using TecproSas.App.Dominio;

namespace TecproSas.App.SitioWeb.Pages_Proyecto
{

    public class CreateModel : PageModel
    {
        private IRepositorioProyecto _repoProyecto {get; set;}
        [BindProperty]
        public Proyecto proyecto {get; set;}

        public CreateModel()
        {
		_repoProyecto = new RepositorioProyecto(new TecproSas.App.Persistencia.AppContext());
        }

        public void OnGet()
        {
        }

        public IActionResult OnPost(Proyecto proyecto)
        {
            if (ModelState.IsValid)
            {
                _repoProyecto.AddProyecto(proyecto);
                return RedirectToPage("/Proyecto/List");
            }
            else
            {
                return Page();
            }
            
        }

    }
}
