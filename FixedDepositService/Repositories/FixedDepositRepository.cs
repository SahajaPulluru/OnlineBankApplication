using UserService.Database;
using UserService.Entities;

namespace FixedDepositService.Repositories
{
    public class FixedDepositRepository
    {
        private readonly UserDbContext db;
        public FixedDepositRepository()
        {
            this.db= new UserDbContext();
        }
        public bool Add(FixedDeposit fd)
        {
            if (DeductBalance(fd))
            {
                db.FixedDeposits.Add(fd);
                db.SaveChanges();
                return true;
            }
            return false;
        }
        private User GetAccountWithTransactions(string accountNumber) => db.Users.First(x => x.AccountNumber == accountNumber);

        public bool DeductBalance(FixedDeposit fd)
        {
            string accountNumber = fd.AccountNumber;
            User user= GetAccountWithTransactions(accountNumber);
            int amount = fd.Amount;
            if (user.Balance - amount >0)
            {
                user.Balance -= amount;
                Transaction t = new Transaction();
                t.AccountNumber = accountNumber;
                t.TransactionType = accountNumber[4].ToString();
                t.TransDate = DateTime.UtcNow;
                t.Amount = amount;
                db.Transactions.Add(t);
                return true;
            }
            return false;
           
        }
        public List<FixedDeposit> GetAll(string accountNumber)
        {
            return db.FixedDeposits.Where(i => i.AccountNumber == accountNumber).ToList();
        }


    }
}
