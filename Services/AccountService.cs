using FIOD.Data;
using FIOD.Models;
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

        public bool TestID (string ID)
        {
            string[] words = ID.Split(new char[] { ' ' });
            if (words.Count() > 1) return false;
            foreach (string word in words)
            {
                Char[] letters = word.ToCharArray();
                foreach (Char letter in letters)
                {
                    if (!Char.IsDigit(letter)) return false;
                }
            }
            return true;
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
        public Account? GetAccountId(string id)
        {
            if (_context.Accounts != null)
            {
                var account = _context.Accounts.Find(int.Parse(id));
                return account;
            }
            return null;
        }
        /*
        IdResult = 1: Аккаунт успешно зарегистрирован!
        IdResult = 2: Введено некоректное ФИО
        IdResult = 3: Введен некоректный логин
        IdResult = 4: Введена некоректная дата рождения
        IdResult = 5: Введен существующий логин
        */
        public string AddAccount(Account newAccount)
        {
            if (!TestFIO(newAccount.FIO)) return "2";
            if (!TestLogin(newAccount.Login)) return "3";
            if (!TestDOB(newAccount.DateOfBirth)) return "4";
            if (!TestExistingLogin(newAccount.Login)) return "5";
            _context.Accounts.Add(newAccount);
            _context.SaveChanges();
            return "1";
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