using Microsoft.AspNetCore.Mvc;
using SmartMonitoringSystem.DTO;
using SmartMonitoringSystem.Interface;
using SmartMonitoringSystem.Models;

namespace SmartMonitoringSystem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserRepository userRepository;
        public UserController(IUserRepository userRepository)
        {
            this.userRepository = userRepository;
        }
        [HttpGet]
        public IEnumerable<User> Get()
        {
            return userRepository.GetAll();
        }

        [HttpPost("Login")]        
        public ActionResult<User> Login([FromBody]LoginData logindata)
        {            
            var user = userRepository.Find(u => u.UserName.Equals(logindata.UserName) && u.Password.Equals(logindata.Password)).SingleOrDefault();
            if (user == null)
            {
                return NotFound();
            }

            return user;
        }
    }
}
