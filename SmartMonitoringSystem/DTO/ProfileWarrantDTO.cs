using SmartMonitoringSystem.Models;

namespace SmartMonitoringSystem.DTO
{
    public class ProfileWarrantDTO
    {
        public long ProfileId { get; set; }
        public string Location { get; set; }
        public string JudgeName { get; set; }
        public string CrimeDescription { get; set; }
        public long WarrantStatusId { get; set; }
        public DateOnly IssueDate { get; set; }

    }
}
