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
    public class DeleteModel : PageModel
    {
        private IRepositorioLogin _repoLogin {get; set;}
        [BindProperty]
        public Login login {get; set;}

        public DeleteModel()
        {
            _repoLogin = new RepositorioLogin(new TecproSas.App.Persistencia.AppContext());
        }

        public void OnGet(int id)
        {
            login = _repoLogin.GetLogin(id);
        }

        public IActionResult OnPost()
        {
            _repoLogin.DeleteLogin(login.loginId);
            return RedirectToPage("/Login/List");
        }
    }
}
