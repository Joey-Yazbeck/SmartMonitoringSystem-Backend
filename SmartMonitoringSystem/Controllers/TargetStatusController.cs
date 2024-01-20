using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SmartMonitoringSystem.Interface;
using SmartMonitoringSystem.Models;

namespace SmartMonitoringSystem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TargetStatusController : ControllerBase
    {
        private readonly ITargetStatusRepository targetStatusRepository;
        public TargetStatusController(ITargetStatusRepository targetStatusRepository)
        {
            this.targetStatusRepository = targetStatusRepository;
        }
        [HttpGet]
        public IEnumerable<TargetStatus> Get()
        {
            return targetStatusRepository.GetAll();
        }


    }
}
