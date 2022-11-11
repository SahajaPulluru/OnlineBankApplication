using Microsoft.AspNetCore.Authorization;
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
        public IActionResult Login( Login login)
        {
            var user=db.Login(login);
            if(user!=null)
                return StatusCode(200,user);
            return StatusCode(500, login);
        }
    }
}
