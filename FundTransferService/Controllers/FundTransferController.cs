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
        public IActionResult Transfer(FundTransfer transfer)
        {
            repo.Transfer(transfer);
            return StatusCode(200,transfer);
        }
        [HttpGet]
        [Route("GetTransaction/{accountNumber}")]
        public IActionResult GetTransactions(string accountNumber)
        {
            List<Transaction> transactions = repo.GetTransactions(accountNumber);
            return StatusCode(200, transactions);
        }
        [HttpGet]
        [Route("GetTransferDetails/{accountNumber}")]
        public IActionResult GetTransferDetails(string accountNumber)
        {
          List<FundTransfer> f=repo.GetTransferDetails(accountNumber);
            return StatusCode(200, f);
        }
    }  
}
