using SmartMonitoringSystem.Models;

namespace SmartMonitoringSystem.DTO
{
    public class AddProfileDTO
    {
        public int ProfileId { get; set; }
        public string FullName { get; set; } = null!;

        public string MotherName { get; set; } = null!;

        public DateOnly DateOfBirth { get; set; }

        public long GenderId { get; set; }

        public long NationalityId { get; set; }

        public long FamilyStatusId { get; set; }

    }
}
