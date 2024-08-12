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

        public void OnPost()
        {
            if (id > 0)
            _service.DeleteAccount(id);
        }
    }
}
