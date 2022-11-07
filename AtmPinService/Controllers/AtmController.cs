using AtmPinService.Repositories;
using Microsoft.AspNetCore.Mvc;
using UserService.Entities;

namespace AtmPinService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AtmController : ControllerBase
    {
        private readonly AtmRepository repo;
        public AtmController()
        {
            this.repo = new AtmRepository();
        }
        [HttpPost]
        [Route("AddAtmPin")]
        public IActionResult AddAtmPin(AtmPin atmpin)
        {
            repo.AddAtmPin(atmpin);
            return StatusCode(200, atmpin);
        }
        [HttpPut]
        [Route("UpdateAtmPin")]
        public IActionResult UpdateAtmPin(int oldAtmpin, int newAtmPin,string accountNumber)
        {
           AtmPin a= repo.UpdateAtmPin(oldAtmpin, newAtmPin,accountNumber);
            return StatusCode(200,a);
        }

    }
}
