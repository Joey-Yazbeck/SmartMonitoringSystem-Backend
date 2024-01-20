using SmartMonitoringSystem.Models;

namespace SmartMonitoringSystem.DTO
{
    public class ProfileDTO
    {
        public long ProfileId { get; set; }

        public string FullName { get; set; } = null!;

        public string MotherName { get; set; } = null!;

        public DateOnly DateOfBirth { get; set; }

        public virtual FamilyStatus FamilyStatus { get; set; } = null!;

        public virtual Gender Gender { get; set; } = null!;

        public virtual Nationality Nationality { get; set; } = null!;
        public virtual TargetStatus TargetStatus { get; set; } = null!;

        public int CountOfWarrants { get; set; } = 0;
        public virtual ICollection<Warrant> Warrants { get; set; } = new List<Warrant>();
    }
}
