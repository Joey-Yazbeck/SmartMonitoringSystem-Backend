using SmartMonitoringSystem.Interface;
using SmartMonitoringSystem.Models;

namespace SmartMonitoringSystem.Repositories
{
    public class CameraRepository : BaseRepository<Camera>, ICameraRepository
    {
        public CameraRepository(FypContext context) : base(context)
        {
        }
    }
}
