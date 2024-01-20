using SmartMonitoringSystem.Models;

namespace SmartMonitoringSystem.DTO
{
    public class TargetDTO
    {
        public long TargetId { get; set; }

        public long ProfileId { get; set; }

        public long TargetStatusId { get; set; }

        public virtual Photo? Photo { get; set; }

        public virtual ProfileDTO Profile { get; set; } = null!;

        public virtual TargetStatus TargetStatus { get; set; } = null!;
    }
}
