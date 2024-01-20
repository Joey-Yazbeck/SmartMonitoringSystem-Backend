using SmartMonitoringSystem.Models;

namespace SmartMonitoringSystem.DTO
{
    public class AddWarrantDTO
    {
        public int ProfileId { get; set; }
        public string Location { get; set; }

        public string JudgeName { get; set; } 
        public string CrimeDescription { get; set; }

    }
}
