using SmartMonitoringSystem.DTO;
using SmartMonitoringSystem.Models;

namespace SmartMonitoringSystem.Interface
{
    public interface IWarrantRepository : IBaseRepository<Warrant>
    {
        public bool AddWarrant(AddWarrantDTO warrantDTO);
        public List<ProfileWarrantDTO> GetByProfileId(long id);
    }
}
