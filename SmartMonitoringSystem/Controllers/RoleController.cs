using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SmartMonitoringSystem.Interface;
using SmartMonitoringSystem.Models;

namespace SmartMonitoringSystem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RoleController : ControllerBase
    {
        private readonly IRoleRepository roleRepository;
        public RoleController(IRoleRepository roleRepository)
        {
            this.roleRepository = roleRepository;
        }
        [HttpGet]
        public IEnumerable<Role> Get()
        {
            return roleRepository.GetAll();
        }

        [HttpPost]
        public void Post([FromBody] Role role)
        {
            roleRepository.Add(role);
            roleRepository.Save();
        }
    }
}
