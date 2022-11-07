
using Microsoft.EntityFrameworkCore;
using UserService.Entities;
using System.Security.Principal;

namespace UserService.Database
{
    public class UserDbContext : DbContext
    {
        public DbSet<Transaction> Transactions { get; set; }
        public DbSet<FundTransfer> FundTransfers { get; set; }
        public DbSet<AtmPin> AtmPins { get; set; }
        public DbSet<Checkbook> Checkbooks { get; set; }
        public DbSet<User> Users { get; set; }
       

       

       
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //define connection string.
            optionsBuilder.UseSqlServer(@"Server=localhost;Trusted_Connection=True;Initial Catalog=BankAppData");
        }
      
    }
}
