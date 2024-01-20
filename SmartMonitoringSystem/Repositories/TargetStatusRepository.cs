using SmartMonitoringSystem.Interface;
using SmartMonitoringSystem.Models;

namespace SmartMonitoringSystem.Repositories
{
    public class TargetStatusRepository : BaseRepository<TargetStatus> , ITargetStatusRepository
    {
        public TargetStatusRepository(FypContext fypContext):base(fypContext)
        {
                
        }
    }
}
