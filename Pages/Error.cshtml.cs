using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace FIOD.Pages;

[ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
[IgnoreAntiforgeryToken]
public class ErrorModel : PageModel
{
    public object? Error {get;set;}
    public object? Id { get; set; }

    private readonly ILogger<ErrorModel> _logger;

    public ErrorModel(ILogger<ErrorModel> logger)
    {
        _logger = logger;
    }


    public void OnGet()
    {
        //RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier;
        Error = RouteData.Values["IdError"];

        switch (Error)
        {
            case "2":
            Error = "Введено некоректное ФИО";
            break;
            case "3":
            Error = "Введен некоректный логин";
            break;
            case "4":
            Error = "Введена некоректная дата рождения";
            break;
            case "5":
            Error = "Введен существующий логин";
            break;
        }
        
    }
}