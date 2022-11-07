using Microsoft.EntityFrameworkCore;
using System.Security.Principal;
using UserService.Database;
using UserService.Entities;

namespace FundTransferService.Repositories
{
    public class FundTransferRepository
    {
        private readonly UserDbContext db;
        static int i = 1;
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
            try
            {
                // retrieve origin account
                var originAccount = GetAccountWithTransactions(transfer.SourceAccNumber);
                int amount = transfer.TransferAmount;
                if (originAccount.Balance - amount > 0)
                {
                    originAccount.Balance -= amount;
                    db.Transactions.Add(
                        new Transaction
                        {
                            Id = 0,
                            TransactionType = (char)TransactionType.Transfer,
                            AccountNumber = transfer.SourceAccNumber,
                            TransDate = DateTime.UtcNow,
                            Amount = amount
                        });

                    var destinationAccount = GetAccountWithTransactions(transfer.DestAccNumber);

                    destinationAccount.Balance += transfer.TransferAmount;

                    // add to destination account as a deposit with comment including details
                    db.Transactions.Add(
                        new Transaction
                        {
                            Id = 0,
                            TransactionType = (char)TransactionType.Transfer,
                            AccountNumber = transfer.DestAccNumber,
                            TransDate = DateTime.UtcNow,
                            Amount = amount
                        });
                }
                // update database
                db.SaveChanges();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.InnerException.Message);
            }
        }

    }
}
