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
    public class DeleteModel : PageModel
    {
        private IRepositorioServicio _repoServicio {get; set;}
        [BindProperty]
        public Servicio servicio {get; set;}

        public DeleteModel()
        {
            _repoServicio = new RepositorioServicio(new TecproSas.App.Persistencia.AppContext());
        }

        public void OnGet(int id)
        {
            servicio = _repoServicio.GetServicio(id);
        }

        public IActionResult OnPost()
        {
            _repoServicio.DeleteServicio(servicio.servicioId);
            return RedirectToPage("/Servicio/List");
        }

    }
}
