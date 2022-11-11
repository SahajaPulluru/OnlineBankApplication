using Microsoft.AspNetCore.Mvc;
using System.Reflection.Metadata;
using UserService.Database;
using UserService.Entities;
using UserService.Utilities;
namespace UserService.Repositories
{
    public class UserRepository
    {
        private readonly UserDbContext context;
        public UserRepository()
        {
            this.context = new UserDbContext();
        }
        public void Register(User user)
        {
            AccountNumberHelper acc=new AccountNumberHelper();
            user.AccountNumber=acc.GenerateAccountUniqueId(user.AccountTypeId);
            user.Balance = 10000;
            AtmPin atmPin=new AtmPin();
            atmPin.AccountNumber=user.AccountNumber;
            atmPin.Atmpin = 1234;
            AddAtmPin(atmPin);
            context.Users.Add(user);
            context.SaveChanges();
        }
        public void AddAtmPin(AtmPin atmpin)
        {
            context.AtmPins.Add(atmpin);
            context.SaveChanges();
        }
        public User Login(Login login)
        {
            User user = context.Users.SingleOrDefault(s => s.UserName==login.Username && s.Password == login.Password);
            if (user == null)
                return null;
            return user;

        }
        public string GetAccountNumber(User user){
            return user.AccountNumber;
        }
        public User GetAccountWithTransactions(string accountNumber) => context.Users.First(x => x.AccountNumber == accountNumber);


    }
}
