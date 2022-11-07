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
            user.Balance = 0;
            context.Users.Add(user);
            context.SaveChanges();
        }
        public bool Login(string username,string password)
        {
            User user = context.Users.Single(s => s.UserName.Equals(username));
            if(user.Password==password)
            {
                return true;
            }
            return false;
        }
        public User Get(string username, string password)
        {
            User user = context.Users.Single(s => s.UserName.Equals(username) && s.Password.Equals(password));  
            return user;
        }
        public string GetAccountNumber(User user){
            return user.AccountNumber;
        }
        
    }
}
