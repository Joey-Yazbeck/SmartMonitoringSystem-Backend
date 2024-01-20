using Microsoft.AspNetCore.Mvc;
using SmartMonitoringSystem.Interface;
using SmartMonitoringSystem.Models;

namespace SmartMonitoringSystem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FamilyStatusController : ControllerBase
    {
        private readonly IFamilyStatusRepository familyStatusRepository;
        public FamilyStatusController(IFamilyStatusRepository familyStatusRepository)
        {
            this.familyStatusRepository = familyStatusRepository;
        }
        [HttpGet]
        public IEnumerable<FamilyStatus> Get()
        {
            return familyStatusRepository.GetAll();
        }

        [HttpPost]
        public void Post([FromBody] FamilyStatus familyStatus)
        {
            familyStatusRepository.Add(familyStatus);
            familyStatusRepository.Save();
        }

    }
}
