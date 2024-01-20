using Microsoft.EntityFrameworkCore;
using SmartMonitoringSystem.DTO;
using SmartMonitoringSystem.Interface;
using SmartMonitoringSystem.Models;

namespace SmartMonitoringSystem.Repositories
{
    public class ProfileRepository : BaseRepository<Profile>, IProfileRepository
    {
        private FypContext context;
        public ProfileRepository(FypContext context) :base(context)
        {
            this.context = context;
        }
        public List<ProfileDTO> GetProfilesDto()
        {
            return context.Profiles.Where(profile=> profile.Target==null || profile.Target.TargetStatus.TargetStatus1.ToLower().Equals("inactive")).Select(profile => new ProfileDTO()
            {
                CountOfWarrants = profile.Warrants.Count,
                DateOfBirth = profile.DateOfBirth,
                FamilyStatus = profile.FamilyStatus,
                FullName = profile.FullName,
                Gender = profile.Gender,
                MotherName = profile.MotherName,
                Nationality = profile.Nationality,
                ProfileId = profile.ProfileId,
                TargetStatus=profile.Target == null? null:profile.Target.TargetStatus

            }).ToList();
        }
        public List<Profile> GetProfilesWithWarrants()
        {
            return context.Profiles.Include(p => p.Warrants).ToList();
        }
    }
}
