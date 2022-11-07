using Microsoft.AspNetCore.Mvc;
using UserService.Repositories;
using UserService.Entities;
namespace TransactionService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TransactionController : ControllerBase
    {
        private readonly TransactionsRepository repo;
        [HttpGet]
        [Route("Get/{accountNumber}")]
        public IActionResult Get(string accountNumber)
        {
            List<Transaction> transactions = repo.GetTransactions(accountNumber);
            return StatusCode(200,transactions);
        }

    }
}
