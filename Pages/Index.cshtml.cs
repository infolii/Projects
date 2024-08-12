//dotnet new page --name PizzaList --namespace ContosoPizza.Pages --output Pages
using FIOD.Models;
using FIOD.Service;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace FIOD.Pages;

public class IndexModel : PageModel
{
    private readonly AccountService _service;
    [BindProperty]
    public IEnumerable<Account> AccountList { get;set; } = default!;
    public Account Account {get; set;} = default!;
    [BindProperty]
    public Account newAccount {get; set;} = default!;
    public string? IdResult {get; set;}

    public IndexModel(AccountService service)
    {
        _service = service;
    }

    public void OnGet()
    {
        AccountList = _service.GetAccounts();
        if (RouteData.Values["IdResult"] != null)
        {
            IdResult = RouteData.Values["IdResult"].ToString();
        }
    }
    public IActionResult OnPost()
    {
        IdResult = _service.AddAccount(newAccount);
        if (IdResult != "1") return RedirectToPage("Error", new {IdError = IdResult});
        return RedirectToAction("Get",new {IdResult = IdResult});
    }
}
