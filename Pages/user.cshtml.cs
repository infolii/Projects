using FIOD.Models;
using FIOD.Service;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace FIOD.Pages
{
    public class userModel : PageModel
    {
        private readonly AccountService _service;

         [BindProperty]
        public string id {get;set;}
        public Account? Account {get; set;}
        public userModel(AccountService service)
        {
            _service = service;
        }
        public IActionResult OnGet()
        {
            if (RouteData.Values["Id"] != null)
            {
                id = RouteData.Values["Id"].ToString();
                Account = _service.GetAccountId(id);
                if (Account == null)
                {
                    return RedirectToPage("Error", new {IdError = "7"});
                }
                return new OkResult();
            }
            return BadRequest();
        }
        public IActionResult OnPost()
        {
            if (!_service.TestID(id))
            {
                return RedirectToPage("Error", new {IdError = "6"});
            }
            return RedirectToAction("Get",new {Id = id});
        }
    }
}
