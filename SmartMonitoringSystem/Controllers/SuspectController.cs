using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SmartMonitoringSystem.DTO;
using SmartMonitoringSystem.Interface;
using SmartMonitoringSystem.Models;
using SmartMonitoringSystem.Repositories;

namespace SmartMonitoringSystem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SuspectController : ControllerBase
    {
        private readonly ISuspectRepository suspectRepository;
        public SuspectController(ISuspectRepository suspectRepository)
        {
            this.suspectRepository = suspectRepository;
        }
        [HttpGet]
        public IEnumerable<Suspect> Get()
        {
            return suspectRepository.GetSuspectsWithRelatedEntities();
        }

      
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            Suspect suspect = new()
            {
                SuspectId = id
            };
            suspectRepository.Delete(suspect);
            suspectRepository.Save();

        }
        [HttpPost("LinkToTarget")]
        public void MarkSuspectAsTarget([FromBody] AddSuspectTargetDTO suspectTargetDTO)
        {
            suspectRepository.MarkSuspectAsTarget(suspectTargetDTO);

        }
    }
}
