using SmartMonitoringSystem.DTO;
using SmartMonitoringSystem.Models;

namespace SmartMonitoringSystem.Interface
{
    public interface ITargetRepository : IBaseRepository<Target>
    {
        List<TargetDTO> GetTargetsDTO();
        bool AddTarget(AddTargetDTO addTargetDTO);
        Target GetTargetWithProfile(long id);

    }
}
