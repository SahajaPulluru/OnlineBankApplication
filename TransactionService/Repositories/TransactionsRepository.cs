using Microsoft.EntityFrameworkCore;
using UserService.Database;
using UserService.Entities;

namespace UserService.Repositories
{
    public class TransactionsRepository
    {
        private readonly UserDbContext context;
        public TransactionsRepository()
        {
            this.context = new UserDbContext();
        }
        public List<Transaction> GetTransactions(string accountnumber)
        {
            return context.Transactions.Where(t =>t.AccountNumber==accountnumber).OrderBy(x => x.TransDate).ToList(); 
        }
     

    }
}
