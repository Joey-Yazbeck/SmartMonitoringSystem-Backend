using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SmartMonitoringSystem.DTO;
using SmartMonitoringSystem.Interface;
using SmartMonitoringSystem.Models;

namespace SmartMonitoringSystem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AlertController : ControllerBase
    {
        private readonly IAlertRepository alertRepository;
        public AlertController(IAlertRepository alertRepository)
        {
            this.alertRepository = alertRepository;
        }
        [HttpGet]
        public IEnumerable<GetAlertDTO> Get()
        {
            return alertRepository.GetAlertsDTO();
        }       

        [HttpPut("Monitor/{AlertId}")]
        public void Put(long AlertId)
        {
            alertRepository.MarkAlertToBeMonitored(AlertId);
        }
    }
}
