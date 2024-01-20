using SmartMonitoringSystem.Interface;
using SmartMonitoringSystem.Models;

namespace SmartMonitoringSystem.Repositories
{
    public class WarrantStatusRepository : BaseRepository<WarrantStatus>, IWarrantStatusRepository
    {
        public WarrantStatusRepository(FypContext context) : base(context)
        {
        }
    }
}
