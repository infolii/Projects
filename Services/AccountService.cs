using FIOD.Data;
using FIOD.Models;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace FIOD.Service
{
    public class AccountService
    {
        private readonly AccountContext _context;
        public AccountService(AccountContext context)
        {
            _context = context;
        }

        public bool TestFIO (string FIO)
        {
            string[] words = FIO.Split(new char[] { ' ' });
            if (words.Count() < 2) return false;
            foreach (string word in words)
            {
                Char[] letters = word.ToCharArray();
                foreach (Char letter in letters)
                {
                    if (!Char.IsLetter(letter)) return false;
                }
            }
            //if (_context.Accounts.FirstOrDefault(acc => acc.FIO == FIO) != null) return false;
            return true;
        }
        public bool TestLogin(string Login)
        {
            string[] words = Login.Split(new char[] { ' ' });
            if (words.Count() > 1) return false;
            foreach (string word in words)
            {
                Char[] letters = word.ToCharArray();
                foreach (Char letter in letters)
                {
                    if (!(Char.IsLetterOrDigit(letter) && (1024 > letter || letter > 1279))) return false;
                }
            }
            return true;
        }
        public bool TestDOB(DateTime DateOfBirth )
        {
            if (DateOfBirth > DateTime.Now) return false;
            return true;
        }
        public bool TestExistingLogin(string Login)
        {
            if (_context.Accounts.FirstOrDefault(acc => acc.Login == Login) != null) return false;
            return true;
        }

        public IEnumerable<Account> GetAccounts()
        {
            if (_context.Accounts != null)
            {
                return _context.Accounts
                .AsNoTracking()
                .ToList();
            }
            else return new List<Account>();
        }
        /*public Account? GetAccountId(int id)
        {
            if (_context.Accounts != null)
            {
                var account = _context.Accounts.Find(id);
            }
            return account;
        }*/
        /*
        IdResult = 1: Аккаунт успешно зарегистрирован!
        IdResult = 2: Введено некоректное ФИО
        IdResult = 3: Введен некоректный логин
        IdResult = 4: Введена некоректная дата рождения
        IdResult = 5: Введен существующий логин
        */
        public IResult AddAccount(Account newAccount)
        {
            if (!TestFIO(newAccount.FIO)) return Results.BadRequest(new {messege = "Введено некоректное ФИО"});
            if (!TestLogin(newAccount.Login)) return Results.BadRequest(new {messege = "Введен некоректный логин"});
            if (!TestDOB(newAccount.DateOfBirth)) return Results.BadRequest(new {messege = "Введена некоректная дата рождения"});
            if (!TestExistingLogin(newAccount.Login)) return Results.BadRequest(new {messege = "Введен существующий логин"});
            _context.Accounts.Add(newAccount);
            _context.SaveChanges();
            return Results.Ok(new { message = "Аккаунт успешно зарегистрирован!" });
        }
        public void DeleteAccount(int id)
        {
            if (_context.Accounts != null && _context.Accounts.Find(id) != null)
            {
                var DelAcc = _context.Accounts.Find(id);
                _context.Accounts.Remove(DelAcc);
                _context.SaveChanges();
            }
            
        } 
    }
}