using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SmartMonitoringSystem.Interface;
using SmartMonitoringSystem.Models;

namespace SmartMonitoringSystem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WarrantStatusController : ControllerBase
    {
        private readonly IWarrantStatusRepository warrantStatusRepository;
        public WarrantStatusController(IWarrantStatusRepository warrantStatusRepository)
        {
            this.warrantStatusRepository = warrantStatusRepository;
        }
        [HttpGet]
        public IEnumerable<WarrantStatus> Get()
        {
            return warrantStatusRepository.GetAll();
        }

        [HttpPost]
        public void Post([FromBody] WarrantStatus warrantStatus)
        {
            warrantStatusRepository.Add(warrantStatus);
            warrantStatusRepository.Save();
        }
    }
}
