using SmartMonitoringSystem.DTO;
using SmartMonitoringSystem.Models;

namespace SmartMonitoringSystem.Interface
{
    public interface IProfileRepository : IBaseRepository<Profile>
    {
        List<ProfileDTO> GetProfilesDto();
        List<Profile> GetProfilesWithWarrants();
    }
}
