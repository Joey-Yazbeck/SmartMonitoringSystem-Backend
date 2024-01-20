using SmartMonitoringSystem.Interface;
using SmartMonitoringSystem.Models;

namespace SmartMonitoringSystem.Repositories
{
    public class UserRepository : BaseRepository<User>, IUserRepository
    {
        private FypContext context;
        public UserRepository(FypContext context):base(context) 
        {
            this.context = context;
        }
    }
}
