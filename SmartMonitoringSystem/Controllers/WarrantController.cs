using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SmartMonitoringSystem.DTO;
using SmartMonitoringSystem.Interface;
using SmartMonitoringSystem.Models;

namespace SmartMonitoringSystem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WarrantController : ControllerBase
    {
        private readonly IWarrantRepository warrantRepository;
        public WarrantController(IWarrantRepository warrantRepository)
        {
            this.warrantRepository = warrantRepository;
        }
        [HttpGet]
        public IEnumerable<Warrant> Get()
        {
            return warrantRepository.GetAll();
        }

        [HttpGet("{profileId}")]
        public IEnumerable<ProfileWarrantDTO> GetProfileWarrant(long profileId)
        {
            return warrantRepository.GetByProfileId(profileId);
        }

        [HttpPost]
        public void Post([FromBody] AddWarrantDTO warrant)
        {
            warrantRepository.AddWarrant(warrant);
            warrantRepository.Save();
        }
    }
}
