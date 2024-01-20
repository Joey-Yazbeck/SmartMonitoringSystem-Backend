using Microsoft.AspNetCore.Mvc;
using SmartMonitoringSystem.Interface;
using SmartMonitoringSystem.Models;

namespace SmartMonitoringSystem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NationalityController : ControllerBase
    {
        private readonly INationalityRepository nationalityRepository;
        public NationalityController(INationalityRepository nationalityRepository)
        {
            this.nationalityRepository = nationalityRepository;
        }
        [HttpGet]
        public IEnumerable<Nationality> Get()
        {
            return nationalityRepository.GetAll();
        }

        [HttpPost]
        public void Post([FromBody] Nationality nationality)
        {
            nationalityRepository.Add(nationality);
            nationalityRepository.Save();
        }
    }
}
