using Microsoft.AspNetCore.Mvc;
using UserService.Entities;
using UserService.Repositories;
namespace UserService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly UserRepository db;
        public UserController()
        {
            this.db = new UserRepository();
        }
        [HttpPost]
        [Route("Register")]
        public IActionResult Register(User user)
        { 
            db.Register(user);
            return StatusCode(200, user);
        }
        [HttpPost]
        [Route("Login")]
        public IActionResult Login(string username,string password)
        {
            bool flag = db.Login(username, password);
            if (flag == true)
            {
                User user = db.Get(username, password);
                return StatusCode(200, user);
            }
            return StatusCode(500, "User Not Found");
        }
    }
}
