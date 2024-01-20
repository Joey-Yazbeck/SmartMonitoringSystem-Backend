using SmartMonitoringSystem.Interface;
using SmartMonitoringSystem.Models;

namespace SmartMonitoringSystem.Repositories
{
    public class FamilyStatusRepository : BaseRepository<FamilyStatus>, IFamilyStatusRepository
    {
        public FamilyStatusRepository(FypContext context) : base(context)
        {
        }
    }
}
