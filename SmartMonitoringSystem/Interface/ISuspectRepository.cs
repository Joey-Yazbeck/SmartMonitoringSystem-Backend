using SmartMonitoringSystem.DTO;
using SmartMonitoringSystem.Models;

namespace SmartMonitoringSystem.Interface
{
    public interface ISuspectRepository : IBaseRepository<Suspect>
    {
        List<Suspect> GetSuspectsWithRelatedEntities();
        bool MarkSuspectAsTarget(AddSuspectTargetDTO suspect);
    }
}
