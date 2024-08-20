using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace FIOD.Pages;

[ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
[IgnoreAntiforgeryToken]
public class ErrorModel : PageModel
{
    public string? Error {get;set;}
    public object? Id { get; set; }

    private readonly ILogger<ErrorModel> _logger;

    public ErrorModel(ILogger<ErrorModel> logger)
    {
        _logger = logger;
    }

        /*
        IdResult = 1: Аккаунт успешно зарегистрирован!
        IdResult = 2: Введено некоректное ФИО
        IdResult = 3: Введен некоректный логин
        IdResult = 4: Введена некоректная дата рождения
        IdResult = 5: Введен существующий логин
        IdResult = 6: Введен неверный ID
        IdResult = 7: Аккаунта с таким ID не существует
        */
    public void OnGet()
    {
        //RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier;
        Error = RouteData.Values["IdError"].ToString();

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
            case "6":
            Error = "Введен неверный ID";
            break;
            case "7":
            Error = "Аккаунта с таким ID не существует";
            break;
        }
        
    }
}