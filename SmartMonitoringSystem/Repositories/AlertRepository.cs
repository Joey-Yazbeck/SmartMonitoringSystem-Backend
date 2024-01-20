using Microsoft.EntityFrameworkCore;
using SmartMonitoringSystem.DTO;
using SmartMonitoringSystem.Interface;
using SmartMonitoringSystem.Models;

namespace SmartMonitoringSystem.Repositories
{
    public class AlertRepository : BaseRepository<Alert>, IAlertRepository
    {
        private readonly FypContext _context;
        public AlertRepository(FypContext context) : base(context)
        {
            _context = context;
        }

        public List<GetAlertDTO> GetAlertsDTO()
        {

            List<GetAlertDTO> alertDto = _context.Alerts.Select(x => new GetAlertDTO() { 
                AlertId = x.AlertId,
                FullName = x.Target.Profile.FullName,
                isRead = x.IsRead,
                TargetId= x.TargetId,
                Message = x.Message,
                DateGenerated = x.DateCreated
            }).ToList();

            return alertDto;
        }

        public void MarkAlertToBeMonitored(long AlertId)
        {
                var Alert = GetById(AlertId);
                Alert.IsRead = true;

                Update(Alert);
                Save();

                return;

        }
    }
}
