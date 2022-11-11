using AtmPinService.Models;
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
        [HttpPut]
        [Route("UpdateAtmPin")]
        public IActionResult UpdateAtmPin(NewAtmPin newAtmPin)
        {
           AtmPin a= repo.UpdateAtmPin(newAtmPin);
            return StatusCode(200,a);
        }

    }
}
