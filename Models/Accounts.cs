using Microsoft.EntityFrameworkCore;
namespace FIOD.Models
{
    public class Account
    {
          public int? Id { get; set; }
          public string FIO { get; set; } = default!;
          public DateTime DateOfBirth {get;set;} = default!;
          public string Login { get; set; } = default!;
    }
}