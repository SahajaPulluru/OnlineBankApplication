using UserService.Database;
using UserService.Entities;

namespace AtmPinService.Repositories
{
    public class AtmRepository
    {
        private readonly UserDbContext db;
        public AtmRepository()
        {
            this.db = new UserDbContext();
        }
        public void AddAtmPin(AtmPin atmpin)
        {
            db.AtmPins.Add(atmpin);
            db.SaveChanges();   
        }
        public AtmPin UpdateAtmPin(int oldAtmpin,int newAtmPin,string accountNumber)
        {
            AtmPin p = db.AtmPins.SingleOrDefault(i => i.AccountNumber==accountNumber);
            if (p.Atmpin == oldAtmpin)
            {
                p.Atmpin = newAtmPin;
            }
            
            db.SaveChanges();
            return p;
        }
    }
}
