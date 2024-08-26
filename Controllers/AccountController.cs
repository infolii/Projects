using FIOD.Models;
using FIOD.Service;
using Microsoft.AspNetCore.Mvc;

namespace FIOD.Controllers;

[ApiController]
[Route("api")]
public class AccountController : ControllerBase
{

    //private readonly ILogger<AccountController> _logger;

    private readonly AccountService _service;
    public AccountController(AccountService service)
        {
            _service = service;
            //_logger = logger;
            /*, ILogger<AccountController> logger*/
        }

    [HttpGet("Users")]
    public IEnumerable<Account> Get()
    {
        return _service.GetAccounts();
    }

    [HttpGet("User/{id}")]
    public ActionResult<Account> GetId(int id)
    {
        var Account = _service.GetAccountId(id.ToString());

        if(Account == null) return NotFound();
        return Account;
    }

    [HttpPost("User")]
    public IActionResult Create(Account account)
    {            
        string Result = _service.AddAccount(account);
        if (Result != "7")
        {
            switch (Result)
            {
                case "2":
                return BadRequest("Введено некоректное ФИО");
                break;
                case "3":
                return BadRequest("Введен некоректный логин");
                break;
                case "4":
                return BadRequest("Введена некоректная дата рождения");
                break;
                case "5":
                return BadRequest("Введен существующий логин");
                break;
                case "6":
                return BadRequest("Введен неверный ID");
                break;
                case "8":
                return BadRequest("Аккаунт с таким ID существует");
                break;
            }
        }
        return CreatedAtAction(nameof(Get), new { id = account.Id }, account);
    }
    [HttpDelete("User/{id}")]
    public IActionResult Delete(int id)
    {
        var account = _service.GetAccountId(id.ToString());
    
        if (account is null) return NotFound();
        
        _service.DeleteAccount(id);
    
        return Ok();
    }
}
//некоторые ошибки не будут работать при отсутвии аккаунтов в базе данных