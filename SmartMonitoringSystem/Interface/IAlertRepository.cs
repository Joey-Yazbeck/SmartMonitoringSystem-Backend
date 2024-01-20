using SmartMonitoringSystem.DTO;
using SmartMonitoringSystem.Models;

namespace SmartMonitoringSystem.Interface
{
    public interface IAlertRepository : IBaseRepository<Alert>
    {
        List<GetAlertDTO> GetAlertsDTO();
        void MarkAlertToBeMonitored(long AlertId);
    }
}
