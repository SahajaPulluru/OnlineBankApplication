using UserService.Entities;
using CheckBookService.Repository;
using Microsoft.AspNetCore.Mvc;


namespace CheckBookService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CheckbookController: ControllerBase
    {
        private readonly CheckbookRepository repo;

        public CheckbookController()
        {
            repo = new CheckbookRepository();
        }
        [HttpPost]
        [Route("Add")]
        public IActionResult Add(Checkbook checkbook)
        {
            repo.AddCheckbook(checkbook);
            return StatusCode(200, checkbook);
        }
        [HttpGet]
        [Route("GetAll/{accountNumber}")]
        public IActionResult GetAll(string accountNumber)
        {
            List<Checkbook> checkbooks = repo.GetAll(accountNumber);
            return StatusCode(200, checkbooks);
        }
        


    }
}
