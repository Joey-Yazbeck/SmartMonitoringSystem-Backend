using Microsoft.EntityFrameworkCore;
using SmartMonitoringSystem.DTO;
using SmartMonitoringSystem.Interface;
using SmartMonitoringSystem.Models;

namespace SmartMonitoringSystem.Repositories
{
    public class SuspectRepository : BaseRepository<Suspect>, ISuspectRepository
    {
        private readonly FypContext fypContext;
        private readonly ITargetRepository targetRepository;
        private readonly ITargetStatusRepository targetStatusRepository;
        private readonly IPhotoRepository photoRepository;
        public SuspectRepository(FypContext context, ITargetRepository targetRepository, ITargetStatusRepository targetStatusRepository, IPhotoRepository photoRepository) : base(context)
        {
            this.fypContext = context;
            this.targetRepository = targetRepository;
            this.targetStatusRepository = targetStatusRepository;
            this.photoRepository = photoRepository;
        }

        public List<Suspect> GetSuspectsWithRelatedEntities()
        {
            return fypContext.Suspects.Include(suspect => suspect.Photo).Include(suspect => suspect.Camera)
                .Where(suspect => suspect.Photo.Target == null || suspect.Photo.Target.TargetStatus.TargetStatus1.ToLower().Equals("inactive")).ToList();
        }

        public bool MarkSuspectAsTarget(AddSuspectTargetDTO suspectDTO)
        {
            var existingTarget = targetRepository.Find(target => target.ProfileId == suspectDTO.ProfileId && target.TargetStatus.TargetStatus1.ToLower().Equals("inactive")).SingleOrDefault();//double check inactive;
            if (existingTarget != null)
            {
                existingTarget.TargetStatus = targetStatusRepository.Find(targetstatus => targetstatus.TargetStatus1.ToLower().Equals("active")).Single();
                existingTarget.TargetStatusId = existingTarget.TargetStatus.TargetStatusId;
                targetRepository.Update(existingTarget);
                targetRepository.Save();
                return true;
            }
            else
            {
                Target target = new Target()
                {
                    ProfileId = suspectDTO.ProfileId,
                    TargetStatus = targetStatusRepository.Find(targetstatus => targetstatus.TargetStatus1.ToLower().Equals("active")).Single(),
                };
                var addedTarget = targetRepository.Add(target);
                targetRepository.Save();
                suspectDTO.Suspect.Photo.Target = addedTarget;
                suspectDTO.Suspect.Photo.TargetId = addedTarget.TargetId;
                photoRepository.Update(suspectDTO.Suspect.Photo);
                photoRepository.Save();
                return true;
            }


        }
    }
}
