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
    public class EditModel : PageModel
    {
        private IRepositorioProyecto _repoProyecto {get; set;}
        [BindProperty]
        public Proyecto proyecto {get; set;}

        public EditModel()
        {
            _repoProyecto = new RepositorioProyecto(new TecproSas.App.Persistencia.AppContext());
        }

        public IActionResult OnGet(int id)
        {
            proyecto = _repoProyecto.GetProyecto(id);
            if (proyecto == null)
            {
                return RedirectToPage("/Proyecto/List");
            }
            else
            {
                return Page();
            }
        }


        public IActionResult OnPost(Proyecto proyecto)
        {
            _repoProyecto.UpdateProyecto(proyecto);
            return RedirectToPage("/Cliente/List");
        }
    }
}
