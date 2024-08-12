using FIOD.Models;
using FIOD.Service;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace FIOD.Pages
{
    public class usersModel : PageModel
    {
        private readonly AccountService _service;
         
        public IEnumerable<Account> AccountList { get;set; } = default!;
        public usersModel(AccountService service)
        {
            _service = service;
        }
        public void OnGet()
        {
            AccountList = _service.GetAccounts();
        }
    }
}
