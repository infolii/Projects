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
        public IActionResult Error(string IdResult)
        {
            return RedirectToPage("Error", new {IdError = "IdError"});
        }
        public void OnGet()
        {
            if (RouteData.Values["Id"] != null)
            {
                id = RouteData.Values["Id"].ToString();
                /*if (_service.TestID(id) == "6")
                {
                    return;
                }*/
                Account = _service.GetAccountId(id);
                if (Account == null)
                {
                    return;
                }
            }
        }
        public IActionResult OnPost()
        {
            string IdResult = _service.TestID(id);
            /*if (IdResult == "6") 
            {
                return RedirectToPage("Error", new {IdError = "6"});
            }*/
            if (IdResult == "7") 
            {
                return RedirectToPage("Error", new {IdError = "7"});
            }
            return RedirectToAction("Get",new {Id = id});
        }
    }
}
