using Microsoft.EntityFrameworkCore;
using UserService.Database;
using UserService.Entities;

namespace UserService.Repositories
{
    public class TransactionsRepository
    {
        private readonly UserDbContext db;
        public TransactionsRepository()
        {
            this.db = new UserDbContext();
        }
        public List<Transaction> GetTransactions(string accountnumber)
        {
            IQueryable<Transaction> l= from p in db.Transactions
                                       where p.AccountNumber == accountnumber
                                       select p;
            return l.ToList();

        }
        public User GetAccountWithTransactions(string accountNumber) => db.Users.First(x => x.AccountNumber == accountNumber);

    }
}
