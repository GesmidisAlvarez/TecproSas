using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using TecproSas.App.Persistencia;
using TecproSas.App.Dominio;

namespace TecproSas.App.SitioWeb.Pages_Login
{

    public class CreateModel: PageModel
    {
        private IRepositorioLogin _repoLogin {get; set;}
        [BindProperty]
        public Login login {get; set;}

        public CreateModel()
        {
		_repoLogin = new RepositorioLogin(new TecproSas.App.Persistencia.AppContext());
        }

        public void OnGet()
        {
        }

        public IActionResult OnPost(Login login)
        {
            if (ModelState.IsValid)
            {
                _repoLogin.AddLogin(login);
                return RedirectToPage("/Login/List");
            }
            else
            {
                return Page();
            }
            
        }

    }
}
