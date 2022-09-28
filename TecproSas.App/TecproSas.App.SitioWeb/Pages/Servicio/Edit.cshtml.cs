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
    public class EditModel : PageModel
    {
        private IRepositorioServicio _repoServicio {get; set;}
        [BindProperty]
        public Servicio servicio {get; set;}

        public EditModel()
        {
            _repoServicio = new RepositorioServicio(new TecproSas.App.Persistencia.AppContext());
        }

        public IActionResult OnGet(int id)
        {
            servicio = _repoServicio.GetServicio(id);
            if (servicio == null)
            {
                return RedirectToPage("/Servicio/List");
            }
            else
            {
                return Page();
            }
        }


        public IActionResult OnPost(Servicio servicio)
        {
            _repoServicio.UpdateServicio(servicio);
            return RedirectToPage("/Servicio/List");
        }
    }
}

