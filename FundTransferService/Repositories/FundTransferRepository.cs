using Microsoft.EntityFrameworkCore;
using System.Security.Principal;
using UserService.Database;
using UserService.Entities;

namespace FundTransferService.Repositories
{
    public class FundTransferRepository
    {
        private readonly UserDbContext db;
        public FundTransferRepository()
        {
            this.db = new UserDbContext();
        }
     /*   public List<Transaction> GetTransactions(string accountnumber)
        {
            return db.Transactions.Where(t => t.AccountNumber == accountnumber).OrderBy(x => x.TransDate).ToList();
        }*/
        private User GetAccountWithTransactions(string accountNumber) => db.Users.First(x => x.AccountNumber == accountNumber);
        public void Transfer(FundTransfer transfer)
        {
            db.FundTransfers.Add(transfer);
            db.SaveChanges();
            var originAccount = GetAccountWithTransactions(transfer.SourceAccNumber);
            int amount = transfer.TransferAmount;
            if (originAccount.Balance - amount > 0)
            {
                originAccount.Balance -= amount;
                Transaction t = new Transaction();
                t.AccountNumber = transfer.SourceAccNumber;
                t.TransactionType = (char)TransactionType.Transfer;
                t.TransDate = DateTime.Now;
                t.Amount = amount;
                db.Transactions.Add(t);
                db.SaveChanges();
                var destinationAccount = GetAccountWithTransactions(transfer.DestAccNumber);
                destinationAccount.Balance += transfer.TransferAmount;
                Transaction t1 = new Transaction();
                t1.AccountNumber = transfer.DestAccNumber;
                t1.TransactionType = (char)TransactionType.Transfer;
                t1.TransDate = DateTime.Now;
                t1.Amount = amount;
                db.Transactions.Add(t1);
                db.SaveChanges();
            }
        }
        public List<Transaction> GetTransactions(string accountnumber)
        {
            return db.Transactions.Where(t => t.AccountNumber == accountnumber).OrderBy(x => x.TransDate).ToList();
        }
        public List<FundTransfer> GetTransferDetails(string accountnumber)
        {
            return db.FundTransfers.Where(t => t.SourceAccNumber == accountnumber).ToList();
        }
    }
}
