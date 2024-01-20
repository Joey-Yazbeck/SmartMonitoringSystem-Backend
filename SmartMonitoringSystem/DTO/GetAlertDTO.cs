using SmartMonitoringSystem.Models;

namespace SmartMonitoringSystem.DTO
{
    public class GetAlertDTO
    {
        public long AlertId { get; set; }
        public string FullName { get; set; }
        public Boolean isRead { get; set; }
        public long? TargetId { get; set; }
        public string Message { get; set; }
        public DateOnly DateGenerated { get; set; }

    }
}
