using Microsoft.AspNetCore.Mvc;
using SmartMonitoringSystem.Interface;
using SmartMonitoringSystem.Models;

namespace SmartMonitoringSystem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GenderController : ControllerBase
    {
        private readonly IGenderRepository genderRepository;
        public GenderController(IGenderRepository genderRepository)
        {
            this.genderRepository = genderRepository;
        }
        [HttpGet]
        public IEnumerable<Gender> Get()
        {
            return genderRepository.GetAll();
        }

        [HttpPost]
        public void Post([FromBody] Gender gender)
        {
            genderRepository.Add(gender);
            genderRepository.Save();
        }
    }
}
