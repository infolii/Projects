using FIOD.Models;
using FIOD.Service;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace FIOD.Pages
{
    public class userModel : PageModel
    {
        private readonly AccountService _service;
         
        public IEnumerable<Account> AccountList { get;set; } = default!;
        public Account Account {get; set;} = default!;
        public userModel(AccountService service)
        {
            _service = service;
        }
        public void OnGet()
        {
            
        }
    }
}
