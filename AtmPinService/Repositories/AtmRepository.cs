using AtmPinService.Models;
using Microsoft.AspNetCore.Mvc;
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
        public AtmPin UpdateAtmPin([FromBody]NewAtmPin newAtmPin)
        {
            AtmPin p = db.AtmPins.SingleOrDefault(i => i.AccountNumber == newAtmPin.AccountNumber);
            if (p.Atmpin == newAtmPin.oldAtmPin)
            {
                db.AtmPins.SingleOrDefault(i => i.AccountNumber == newAtmPin.AccountNumber).Atmpin = newAtmPin.newAtmPin;
                db.SaveChanges();
            }
            return p;
        }
    }
}
