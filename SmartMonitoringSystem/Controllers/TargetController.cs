using Microsoft.AspNetCore.Mvc;
using SmartMonitoringSystem.DTO;
using SmartMonitoringSystem.Interface;
using SmartMonitoringSystem.Models;
using SmartMonitoringSystem.Repositories;

namespace SmartMonitoringSystem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TargetController : ControllerBase
    {
        private readonly ITargetRepository targetRepository;
        private readonly ITargetStatusRepository targetStatusRepository;
        public TargetController(ITargetRepository targetRepository, ITargetStatusRepository targetStatusRepository)
        {
            this.targetRepository = targetRepository;
            this.targetStatusRepository= targetStatusRepository;
        }
        [HttpGet]
        public List<TargetDTO> Get()
        {
            return targetRepository.GetTargetsDTO();
        }
        [HttpPost, Route("AddTarget")]
        public bool AddTarget([FromBody] AddTargetDTO target)
        {
            return targetRepository.AddTarget(target);
            
        }
       
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            Target target = targetRepository.GetById(id);
            target.TargetStatus= targetStatusRepository.Find(targetstatus => targetstatus.TargetStatus1.ToLower().Equals("inactive")).Single();
            target.TargetStatusId = target.TargetStatus.TargetStatusId;
            targetRepository.Update(target);
            targetRepository.Save();

        }
        [HttpPut()]
        public void Update(TargetDTO targetDTO)
        {
            Target target = targetRepository.GetTargetWithProfile(targetDTO.TargetId);
            target.Profile.FullName = targetDTO.Profile.FullName;
            target.Profile.MotherName = targetDTO.Profile.MotherName;
            target.Profile.Gender= targetDTO.Profile.Gender;
            target.Profile.DateOfBirth= targetDTO.Profile.DateOfBirth;
            target.Profile.FamilyStatus= targetDTO.Profile.FamilyStatus;
            target.Profile.Nationality = targetDTO.Profile.Nationality;
       
            targetRepository.Update(target);
            targetRepository.Save();

        }
    }
}
