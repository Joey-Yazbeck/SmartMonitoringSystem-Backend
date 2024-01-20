using Microsoft.VisualBasic;
using SmartMonitoringSystem.DTO;
using SmartMonitoringSystem.Interface;
using SmartMonitoringSystem.Models;
using System.Collections.ObjectModel;

namespace SmartMonitoringSystem.Repositories
{
    public class WarrantRepository : BaseRepository<Warrant>, IWarrantRepository
    {
        private FypContext context;

        public WarrantRepository(FypContext context) : base(context)
        {
            this.context = context;
        }

        public bool AddWarrant(AddWarrantDTO warrantDTO)
        {
            try
            {
                Warrant warrant = new()
                {
                    IssueDate = DateOnly.FromDateTime(DateTime.Now),
                    Location = warrantDTO.Location,
                    JudgeName = warrantDTO.JudgeName,
                    CrimeDescription = warrantDTO.CrimeDescription,
                    ProfileId = warrantDTO.ProfileId,
                    WarrantStatusId = 1
                };

                context.Warrants.Add(warrant);
                context.SaveChanges();
                return true;
            } catch (Exception ex)
            {
                return false;
            }

        }

        public List<ProfileWarrantDTO> GetByProfileId(long id)
        {
            try
            {
                return context.Warrants.Where(x => x.ProfileId == id).Select(x => new ProfileWarrantDTO
                {
                    ProfileId = x.ProfileId,
                    Location = x.Location,
                    JudgeName = x.JudgeName,
                    CrimeDescription = x.CrimeDescription,
                    IssueDate = x.IssueDate,
                    WarrantStatusId = x.WarrantStatusId
                }).ToList();
            }
            catch (Exception ex)
            {
                return new List<ProfileWarrantDTO>();
            }
        }
    }
}
