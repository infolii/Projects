using FIOD.Models;
using FIOD.Service;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace FIOD.Pages
{
    public class CreateModel : PageModel
    {
        private readonly AccountService _service;
        [BindProperty]
        public Account newAccount {get; set;} = default!;
        public string? IdResult {get; set;}

        public CreateModel(AccountService service)
        {
            _service = service;
        }
        public void OnGet()
        {
            if (RouteData.Values["IdResult"] != null)
            {
                IdResult = RouteData.Values["IdResult"].ToString();
            }
        }
        public IActionResult OnPost()
        {
            IdResult = _service.AddAccount(newAccount);
            if (IdResult != "1") return RedirectToPage("Error", new {IdError = IdResult});
            return RedirectToPage("Create",new {IdResult = IdResult});
        }
    }
}
