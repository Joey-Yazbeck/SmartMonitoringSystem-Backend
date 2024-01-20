using SmartMonitoringSystem.Interface;
using SmartMonitoringSystem.Models;

namespace SmartMonitoringSystem.Repositories
{
    public class NationalityRepository : BaseRepository<Nationality>, INationalityRepository
    {
        public NationalityRepository(FypContext context) : base(context)
        {
        }
    }
}
