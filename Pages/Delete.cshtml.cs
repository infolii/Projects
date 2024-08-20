using FIOD.Models;
using FIOD.Service;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace FIOD.Pages
{
    public class DeleteModel : PageModel
    {
        private readonly AccountService _service;
        public DeleteModel(AccountService service)
        {
            _service = service;
        }
        [BindProperty]
        public int id {get;set;}

        public IActionResult OnPost()
        {
            string IdResult = _service.TestID(id.ToString());
            if (IdResult == "6") 
            {
                return RedirectToPage("Error", new {IdError = "6"});
            }
            if (IdResult == "7") 
            {
                return RedirectToPage("Error", new {IdError = "7"});
            }
            _service.DeleteAccount(id);
            return RedirectToAction("Post",new {Id = id});
        }
    }
}
