using FixedDepositService.Repositories;
using Microsoft.AspNetCore.Mvc;
using UserService.Entities;

namespace FixedDepositService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FixedDepositController : ControllerBase
    {
        private readonly FixedDepositRepository repo;
        public FixedDepositController()
        {
            this.repo = new FixedDepositRepository();
        }
        [HttpPost]
        [Route("Add")]
        public IActionResult Add(FixedDeposit fd)
        {
            bool flag=repo.Add(fd);
            if (flag)
                return StatusCode(200, fd);
            else
                return StatusCode(500, "Insufficient Balance");
        }
        [HttpGet]
        [Route("GetAll/{accountNumber}")]
        public IActionResult GetAll(string accountNumber)
        {
            List<FixedDeposit> fds = repo.GetAll(accountNumber);
            return StatusCode(200, fds);
        }

    }
}
