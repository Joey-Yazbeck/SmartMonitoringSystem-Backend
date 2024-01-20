using Microsoft.EntityFrameworkCore;
using SmartMonitoringSystem.DTO;
using SmartMonitoringSystem.Interface;
using SmartMonitoringSystem.Models;
using SmartMonitoringSystem.Services;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace SmartMonitoringSystem.Repositories
{
    public class TargetRepository : BaseRepository<Target>, ITargetRepository
    {
        private FypContext context;
        private readonly FileService fileService;
        private readonly IProfileRepository profileRepository;
        private readonly ITargetStatusRepository targetStatusRepository;
        public TargetRepository(FypContext context, FileService fileService, IProfileRepository profileRepository, ITargetStatusRepository targetStatusRepository) : base(context)
        {
            this.context = context;
            this.fileService = fileService;
            this.profileRepository = profileRepository;
            this.targetStatusRepository = targetStatusRepository;
        }
        public List<TargetDTO> GetTargetsDTO()
        {
            return context.Targets.Where(target => target.TargetStatus.TargetStatus1.ToLower().Equals("active")).Select(target => new TargetDTO()
            {
                Profile= new ProfileDTO()
                {
                    CountOfWarrants= target.Profile.Warrants.Count,
                    DateOfBirth = target.Profile.DateOfBirth,
                    FamilyStatus = target.Profile.FamilyStatus,
                    FullName = target.Profile.FullName,
                    Gender = target.Profile.Gender,
                    MotherName = target.Profile.MotherName,
                    Nationality = target.Profile.Nationality,
                    ProfileId = target.Profile.ProfileId,
                    TargetStatus = target.Profile.Target == null ? null : target.Profile.Target.TargetStatus
                },
                ProfileId = target.ProfileId,
                TargetStatus = target.TargetStatus,
                Photo= target.Photo,
                TargetId = target.TargetId,
                TargetStatusId=target.TargetStatusId

            }).ToList();
           
        }

        public bool AddTarget(AddTargetDTO addTargetDTO)
        {

            
            var profile = profileRepository.Find(x => x.ProfileId == addTargetDTO.ProfileId).FirstOrDefault();
            if (profile == null)
            {
                return false;
            }
            var existingTarget = Find(target => target.ProfileId == addTargetDTO.ProfileId && target.TargetStatus.TargetStatus1.ToLower().Equals("inactive")).SingleOrDefault();//double check inactive;
            if (existingTarget != null)
            {
                existingTarget.TargetStatus = targetStatusRepository.Find(targetstatus => targetstatus.TargetStatus1.ToLower().Equals("active")).Single();
                existingTarget.TargetStatusId = existingTarget.TargetStatus.TargetStatusId;
                Update(existingTarget);
                Save();
                return true;
            }
            else
            {
                Target? target = new();
                target.ProfileId = addTargetDTO.ProfileId;
                target.TargetStatusId = targetStatusRepository.Find(targetstatus => targetstatus.TargetStatus1.ToLower().Equals("active")).Single().TargetStatusId;

                var PhotoName = $"Target_{addTargetDTO.ProfileId}.jpg";

                var isPhotSaved = fileService.SaveImageToFile(addTargetDTO.Photo, PhotoName);
                if (!isPhotSaved)
                {
                    return false;
                }

                Photo photo = new()
                {
                    Photo1 = PhotoName
                };

                target.Photo = photo;

                var InsertdeTarget = Add(target);

                Save();

                if (InsertdeTarget.TargetId == 0)
                {
                    return false;
                }

                return true;

            }
            
        }

        public Target GetTargetWithProfile(long id)
        {
            return context.Targets.Include(target => target.Profile).Where(target=>target.TargetId == id).SingleOrDefault();
        }
    }
}
