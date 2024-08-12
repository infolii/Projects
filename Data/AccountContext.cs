using FIOD.Models;
using Microsoft.EntityFrameworkCore;

namespace FIOD.Data
{
    public class AccountContext : DbContext
    {
        public DbSet<FIOD.Models.Account>? Accounts { get; set; }
        public AccountContext(DbContextOptions<AccountContext> options)
            : base(options)
        {
            Database.EnsureCreated();
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Account>().HasData(
            new Account {Id = 1,FIO = "awegdtt rsadg wretg", Login = "tgreagaw", DateOfBirth = new DateTime(1244,12,23)}
        );
    }
    }
}