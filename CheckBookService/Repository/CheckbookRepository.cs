using UserService.Database;
using UserService.Entities;
using Microsoft.EntityFrameworkCore;
using System.Numerics;
namespace CheckBookService.Repository
{
    
    public class CheckbookRepository
    {
        private readonly UserDbContext db;
        public CheckbookRepository()
        {
            db = new UserDbContext();
        }

        public void AddCheckbook(Checkbook checkbook)
        {
            db.Checkbooks.Add(checkbook);
            db.SaveChanges();
        }
        public Checkbook ViewCheckbookDetails(string accountNumber)
        {
            Checkbook checkbook = db.Checkbooks.SingleOrDefault(i => i.AccountNumber == accountNumber);
            return checkbook;

        }

        public List<Checkbook> GetAll(string accountNumber)
        {
            return db.Checkbooks.Where(i=>i.AccountNumber==accountNumber).ToList();
        }
    }
}
