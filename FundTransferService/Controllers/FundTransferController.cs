using FundTransferService.Repositories;
using Microsoft.AspNetCore.Mvc;
using UserService.Entities;

namespace FundTransferService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FundTransferController : ControllerBase
    {
        private readonly FundTransferRepository repo;
        public FundTransferController()
        {
            this.repo = new FundTransferRepository();   
        }
        [HttpPost]
        [Route("Transfer")]
        public IActionResult Trasfer(FundTransfer transfer)
        {
            repo.Transfer(transfer);
            return StatusCode(200,transfer);
        }

    }
}
